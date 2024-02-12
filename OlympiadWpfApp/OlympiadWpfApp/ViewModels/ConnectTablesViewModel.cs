using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using OlympiadWpfApp.Commands;
using OlympiadWpfApp.DataAccess.Contexts;
using OlympiadWpfApp.DataAccess.Entities;

namespace OlympiadWpfApp.ViewModels;

public class ConnectTablesViewModel : INotifyPropertyChanged
{
    private readonly Window _owner;
    private readonly OlympDbContext _olympDbContext;
    private ObservableCollection<OlympiadEntity> _olympiadEntities = null!;
    private ObservableCollection<ParticipantEntity> _participantEntities = null!;
    private ObservableCollection<SportTypeEntity> _sportTypeEntities = null!;
    private bool NeedOlympiad => SelectedOlympiad != null;
    private bool NeedParticipant => SelectedParticipant != null;
    private bool NeedSportType => SelectedSportType != null;
    private bool NeedAllMedals => GoldMedals >= 0 && SilverMedals >= 0 && BronzeMedals >= 0;

    public ObservableCollection<OlympiadEntity> OlympiadEntities
    {
        get => _olympiadEntities;
        set
        {
            _olympiadEntities = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<ParticipantEntity> ParticipantEntities
    {
        get => _participantEntities;
        set
        {
            _participantEntities = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<SportTypeEntity> SportTypeEntities
    {
        get => _sportTypeEntities;
        set
        {
            _sportTypeEntities = value;
            OnPropertyChanged();
        }
    }

    public OlympiadEntity? SelectedOlympiad { get; set; }
    public SportTypeEntity? SelectedSportType { get; set; }
    public ParticipantEntity? SelectedParticipant { get; set; }

    public int GoldMedals { get; set; }
    public int SilverMedals { get; set; }
    public int BronzeMedals { get; set; }

    public Command ConnectOlympiadParticipantCommand { get; set; }
    public Command ConnectOlympiadSportTypeCommand { get; set; }
    public Command ConnectSportTypeParticipantCommand { get; set; }
    public Command OkCommand { get; set; }
    public Command CancelCommand { get; set; }

    public ConnectTablesViewModel(Window owner, OlympDbContext olympDbContext)
    {
        _owner = owner;
        _owner.DataContext = this;
        _olympDbContext = olympDbContext;

        GoldMedals = 0;
        SilverMedals = 0;
        BronzeMedals = 0;

        OlympiadEntities =
            new ObservableCollection<OlympiadEntity>(_olympDbContext.Olympiads.Where(x => !x.IsDeleted).ToList());
        ParticipantEntities =
            new ObservableCollection<ParticipantEntity>(_olympDbContext.Participants.Where(x => !x.IsDeleted).ToList());
        SportTypeEntities = new ObservableCollection<SportTypeEntity>(_olympDbContext.SportTypes.ToList());

        ConnectOlympiadParticipantCommand = new DelegateCommand(_ => ExecuteConnectOlympiadParticipant(),
            _ => NeedOlympiad && NeedParticipant);
        ConnectOlympiadSportTypeCommand =
            new DelegateCommand(_ => ExecuteConnectOlympiadSportType(), _ => NeedOlympiad && NeedSportType);
        ConnectSportTypeParticipantCommand = new DelegateCommand(_ => ExecuteConnectSportTypeParticipant(),
            _ => NeedParticipant && NeedSportType && NeedAllMedals);
        OkCommand = new DelegateCommand(_ => ExecuteOk());
        CancelCommand = new DelegateCommand(_ => ExecuteCancel());
    }


    private void ExecuteConnectOlympiadParticipant()
    {
        if (SelectedParticipant == null || SelectedOlympiad == null) return;
        var entity = new OlympiadParticipantEntity
        {
            Id = _olympDbContext.OlympiadParticipants.Any()
                ? _olympDbContext.OlympiadParticipants.OrderBy(x => x.Id).Last().Id + 1
                : 1,
            OlympiadId = SelectedOlympiad.Id,
            ParticipantId = SelectedParticipant.Id
        };
        if (_olympDbContext.OlympiadParticipants.Contains(entity))
        {
            MessageBox.Show("Такая связь уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        _olympDbContext.OlympiadParticipants.Add(entity);
    }

    private void ExecuteConnectOlympiadSportType()
    {
        if (SelectedSportType == null || SelectedOlympiad == null) return;
        var entity = new SportTypeOlympiadEntity
        {
            Id = _olympDbContext.SportTypeOlympiads.Any()
                ? _olympDbContext.SportTypeOlympiads.OrderBy(x => x.Id).Last().Id + 1
                : 1,
            OlympiadId = SelectedOlympiad.Id,
            SportTypeId = SelectedSportType.Id
        };

        if (_olympDbContext.SportTypeOlympiads.Contains(entity))
        {
            MessageBox.Show("Такая связь уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        _olympDbContext.SportTypeOlympiads.Add(entity);
    }

    private void ExecuteConnectSportTypeParticipant()
    {
        if (SelectedSportType == null || SelectedParticipant == null) return;
        var entity = new SportTypeParticipantEntity
        {
            Id = _olympDbContext.SportTypeParticipants.Any()
                ? _olympDbContext.SportTypeParticipants.OrderBy(x => x.Id).Last().Id + 1
                : 1,
            SportTypeId = SelectedSportType.Id,
            ParticipantId = SelectedParticipant.Id,
            GoldMedals = GoldMedals,
            SilverMedals = SilverMedals,
            BronzeMedals = BronzeMedals
        };
        var alreadyInDb = _olympDbContext.SportTypeParticipants.FirstOrDefault(x =>
            x.ParticipantId == entity.ParticipantId && x.SportTypeId == entity.SportTypeId);
        if (alreadyInDb != default)
        {
            alreadyInDb.GoldMedals += entity.GoldMedals;
            alreadyInDb.SilverMedals += entity.SilverMedals;
            alreadyInDb.BronzeMedals += entity.BronzeMedals;
        }

        _olympDbContext.SportTypeParticipants.Add(entity);
    }

    private void ExecuteOk()
    {
        _owner.DialogResult = true;
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        _owner.Close();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}