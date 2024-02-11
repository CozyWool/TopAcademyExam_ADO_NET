toc.dat                                                                                             0000600 0004000 0002000 00000037216 14562071202 0014447 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP   2                    |            Olymp    16.1    16.1 5    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         �           1262    29027    Olymp    DATABASE     {   CREATE DATABASE "Olymp" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Olymp";
                postgres    false         �           0    0    DATABASE "Olymp"    COMMENT     4   COMMENT ON DATABASE "Olymp" IS 'Database for exam';
                   postgres    false    4840         �            1259    29029    Olympiad    TABLE     �   CREATE TABLE public."Olympiad" (
    id integer NOT NULL,
    year date NOT NULL,
    host_country character varying(100) NOT NULL,
    city character varying(100) NOT NULL,
    season character varying(100) NOT NULL
);
    DROP TABLE public."Olympiad";
       public         heap    postgres    false         �            1259    29067    Olympiad_Participant    TABLE     �   CREATE TABLE public."Olympiad_Participant" (
    id integer NOT NULL,
    olympiad_id integer NOT NULL,
    participant_id integer NOT NULL
);
 *   DROP TABLE public."Olympiad_Participant";
       public         heap    postgres    false         �            1259    29066    Olympiad_Participant_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Olympiad_Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 4   DROP SEQUENCE public."Olympiad_Participant_id_seq";
       public          postgres    false    224         �           0    0    Olympiad_Participant_id_seq    SEQUENCE OWNED BY     _   ALTER SEQUENCE public."Olympiad_Participant_id_seq" OWNED BY public."Olympiad_Participant".id;
          public          postgres    false    223         �            1259    29028    Olympiad_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Olympiad_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Olympiad_id_seq";
       public          postgres    false    216         �           0    0    Olympiad_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Olympiad_id_seq" OWNED BY public."Olympiad".id;
          public          postgres    false    215         �            1259    29036    Participant    TABLE     �   CREATE TABLE public."Participant" (
    id integer NOT NULL,
    surname character varying(100) NOT NULL,
    name character varying(50) NOT NULL,
    father_name character varying(50) NOT NULL,
    birthdate date NOT NULL
);
 !   DROP TABLE public."Participant";
       public         heap    postgres    false         �            1259    29035    Participant_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public."Participant_id_seq";
       public          postgres    false    218         �           0    0    Participant_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Participant_id_seq" OWNED BY public."Participant".id;
          public          postgres    false    217         �            1259    29043 
   Sport_Type    TABLE     h   CREATE TABLE public."Sport_Type" (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);
     DROP TABLE public."Sport_Type";
       public         heap    postgres    false         �            1259    29050    Sport_Type_Olympiad    TABLE     �   CREATE TABLE public."Sport_Type_Olympiad" (
    id integer NOT NULL,
    sport_type_id integer NOT NULL,
    olympiad_id integer NOT NULL
);
 )   DROP TABLE public."Sport_Type_Olympiad";
       public         heap    postgres    false         �            1259    29049    Sport_Type_Olympiad_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Sport_Type_Olympiad_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public."Sport_Type_Olympiad_id_seq";
       public          postgres    false    222         �           0    0    Sport_Type_Olympiad_id_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Sport_Type_Olympiad_id_seq" OWNED BY public."Sport_Type_Olympiad".id;
          public          postgres    false    221         �            1259    29084    Sport_Type_Participant    TABLE       CREATE TABLE public."Sport_Type_Participant" (
    id integer NOT NULL,
    sport_type_id integer NOT NULL,
    participant_id integer NOT NULL,
    gold_medals integer DEFAULT 0 NOT NULL,
    silver_medals integer DEFAULT 0 NOT NULL,
    bronze_medals integer DEFAULT 0 NOT NULL
);
 ,   DROP TABLE public."Sport_Type_Participant";
       public         heap    postgres    false         �            1259    29083    Sport_Type_Participant_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Sport_Type_Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."Sport_Type_Participant_id_seq";
       public          postgres    false    226         �           0    0    Sport_Type_Participant_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public."Sport_Type_Participant_id_seq" OWNED BY public."Sport_Type_Participant".id;
          public          postgres    false    225         �            1259    29042    Sport_Type_id_seq    SEQUENCE     �   CREATE SEQUENCE public."Sport_Type_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Sport_Type_id_seq";
       public          postgres    false    220         �           0    0    Sport_Type_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."Sport_Type_id_seq" OWNED BY public."Sport_Type".id;
          public          postgres    false    219         -           2604    29032    Olympiad id    DEFAULT     n   ALTER TABLE ONLY public."Olympiad" ALTER COLUMN id SET DEFAULT nextval('public."Olympiad_id_seq"'::regclass);
 <   ALTER TABLE public."Olympiad" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    215    216    216         1           2604    29070    Olympiad_Participant id    DEFAULT     �   ALTER TABLE ONLY public."Olympiad_Participant" ALTER COLUMN id SET DEFAULT nextval('public."Olympiad_Participant_id_seq"'::regclass);
 H   ALTER TABLE public."Olympiad_Participant" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    223    224    224         .           2604    29039    Participant id    DEFAULT     t   ALTER TABLE ONLY public."Participant" ALTER COLUMN id SET DEFAULT nextval('public."Participant_id_seq"'::regclass);
 ?   ALTER TABLE public."Participant" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    218    217    218         /           2604    29046    Sport_Type id    DEFAULT     r   ALTER TABLE ONLY public."Sport_Type" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_id_seq"'::regclass);
 >   ALTER TABLE public."Sport_Type" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    219    220         0           2604    29053    Sport_Type_Olympiad id    DEFAULT     �   ALTER TABLE ONLY public."Sport_Type_Olympiad" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_Olympiad_id_seq"'::regclass);
 G   ALTER TABLE public."Sport_Type_Olympiad" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    222    221    222         2           2604    29087    Sport_Type_Participant id    DEFAULT     �   ALTER TABLE ONLY public."Sport_Type_Participant" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_Participant_id_seq"'::regclass);
 J   ALTER TABLE public."Sport_Type_Participant" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    226    225    226         �          0    29029    Olympiad 
   TABLE DATA           J   COPY public."Olympiad" (id, year, host_country, city, season) FROM stdin;
    public          postgres    false    216       4824.dat �          0    29067    Olympiad_Participant 
   TABLE DATA           Q   COPY public."Olympiad_Participant" (id, olympiad_id, participant_id) FROM stdin;
    public          postgres    false    224       4832.dat �          0    29036    Participant 
   TABLE DATA           R   COPY public."Participant" (id, surname, name, father_name, birthdate) FROM stdin;
    public          postgres    false    218       4826.dat �          0    29043 
   Sport_Type 
   TABLE DATA           0   COPY public."Sport_Type" (id, name) FROM stdin;
    public          postgres    false    220       4828.dat �          0    29050    Sport_Type_Olympiad 
   TABLE DATA           O   COPY public."Sport_Type_Olympiad" (id, sport_type_id, olympiad_id) FROM stdin;
    public          postgres    false    222       4830.dat �          0    29084    Sport_Type_Participant 
   TABLE DATA           �   COPY public."Sport_Type_Participant" (id, sport_type_id, participant_id, gold_medals, silver_medals, bronze_medals) FROM stdin;
    public          postgres    false    226       4834.dat �           0    0    Olympiad_Participant_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public."Olympiad_Participant_id_seq"', 1, false);
          public          postgres    false    223         �           0    0    Olympiad_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Olympiad_id_seq"', 1, false);
          public          postgres    false    215         �           0    0    Participant_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Participant_id_seq"', 1, false);
          public          postgres    false    217         �           0    0    Sport_Type_Olympiad_id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public."Sport_Type_Olympiad_id_seq"', 1, false);
          public          postgres    false    221         �           0    0    Sport_Type_Participant_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."Sport_Type_Participant_id_seq"', 1, false);
          public          postgres    false    225         �           0    0    Sport_Type_id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Sport_Type_id_seq"', 1, false);
          public          postgres    false    219         ?           2606    29072 .   Olympiad_Participant Olympiad_Participant_pkey 
   CONSTRAINT     |   ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT "Olympiad_Participant_pkey" PRIMARY KEY (participant_id);
 \   ALTER TABLE ONLY public."Olympiad_Participant" DROP CONSTRAINT "Olympiad_Participant_pkey";
       public            postgres    false    224         7           2606    29034    Olympiad Olympiad_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Olympiad"
    ADD CONSTRAINT "Olympiad_pkey" PRIMARY KEY (id);
 D   ALTER TABLE ONLY public."Olympiad" DROP CONSTRAINT "Olympiad_pkey";
       public            postgres    false    216         9           2606    29041    Participant Participant_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Participant"
    ADD CONSTRAINT "Participant_pkey" PRIMARY KEY (id);
 J   ALTER TABLE ONLY public."Participant" DROP CONSTRAINT "Participant_pkey";
       public            postgres    false    218         =           2606    29055 ,   Sport_Type_Olympiad Sport_Type_Olympiad_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "Sport_Type_Olympiad_pkey" PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public."Sport_Type_Olympiad" DROP CONSTRAINT "Sport_Type_Olympiad_pkey";
       public            postgres    false    222         A           2606    29092 2   Sport_Type_Participant Sport_Type_Participant_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT "Sport_Type_Participant_pkey" PRIMARY KEY (id);
 `   ALTER TABLE ONLY public."Sport_Type_Participant" DROP CONSTRAINT "Sport_Type_Participant_pkey";
       public            postgres    false    226         ;           2606    29048    Sport_Type Sport_Type_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Sport_Type"
    ADD CONSTRAINT "Sport_Type_pkey" PRIMARY KEY (id);
 H   ALTER TABLE ONLY public."Sport_Type" DROP CONSTRAINT "Sport_Type_pkey";
       public            postgres    false    220         B           2606    29056    Sport_Type_Olympiad olymp_FK    FK CONSTRAINT     �   ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "olymp_FK" FOREIGN KEY (olympiad_id) REFERENCES public."Olympiad"(id);
 J   ALTER TABLE ONLY public."Sport_Type_Olympiad" DROP CONSTRAINT "olymp_FK";
       public          postgres    false    4663    216    222         D           2606    29073     Olympiad_Participant olympiad_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT olympiad_fk FOREIGN KEY (olympiad_id) REFERENCES public."Olympiad"(id);
 L   ALTER TABLE ONLY public."Olympiad_Participant" DROP CONSTRAINT olympiad_fk;
       public          postgres    false    224    4663    216         E           2606    29078 #   Olympiad_Participant participant_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT participant_fk FOREIGN KEY (participant_id) REFERENCES public."Participant"(id);
 O   ALTER TABLE ONLY public."Olympiad_Participant" DROP CONSTRAINT participant_fk;
       public          postgres    false    224    218    4665         F           2606    29098 %   Sport_Type_Participant participant_id    FK CONSTRAINT     �   ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT participant_id FOREIGN KEY (participant_id) REFERENCES public."Participant"(id);
 Q   ALTER TABLE ONLY public."Sport_Type_Participant" DROP CONSTRAINT participant_id;
       public          postgres    false    218    4665    226         C           2606    29061 !   Sport_Type_Olympiad sport_type_FK    FK CONSTRAINT     �   ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "sport_type_FK" FOREIGN KEY (sport_type_id) REFERENCES public."Sport_Type"(id);
 O   ALTER TABLE ONLY public."Sport_Type_Olympiad" DROP CONSTRAINT "sport_type_FK";
       public          postgres    false    222    4667    220         G           2606    29093 $   Sport_Type_Participant sport_type_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT sport_type_fk FOREIGN KEY (sport_type_id) REFERENCES public."Sport_Type"(id);
 P   ALTER TABLE ONLY public."Sport_Type_Participant" DROP CONSTRAINT sport_type_fk;
       public          postgres    false    226    220    4667                                                                                                                                                                                                                                                                                                                                                                                          4824.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014245 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4832.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014244 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4826.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014247 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4828.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014251 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4830.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014242 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           4834.dat                                                                                            0000600 0004000 0002000 00000000005 14562071202 0014246 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        \.


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           restore.sql                                                                                         0000600 0004000 0002000 00000031240 14562071202 0015363 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Olymp";
--
-- Name: Olymp; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Olymp" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "Olymp" OWNER TO postgres;

\connect "Olymp"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE "Olymp"; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE "Olymp" IS 'Database for exam';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Olympiad; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Olympiad" (
    id integer NOT NULL,
    year date NOT NULL,
    host_country character varying(100) NOT NULL,
    city character varying(100) NOT NULL,
    season character varying(100) NOT NULL
);


ALTER TABLE public."Olympiad" OWNER TO postgres;

--
-- Name: Olympiad_Participant; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Olympiad_Participant" (
    id integer NOT NULL,
    olympiad_id integer NOT NULL,
    participant_id integer NOT NULL
);


ALTER TABLE public."Olympiad_Participant" OWNER TO postgres;

--
-- Name: Olympiad_Participant_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Olympiad_Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Olympiad_Participant_id_seq" OWNER TO postgres;

--
-- Name: Olympiad_Participant_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Olympiad_Participant_id_seq" OWNED BY public."Olympiad_Participant".id;


--
-- Name: Olympiad_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Olympiad_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Olympiad_id_seq" OWNER TO postgres;

--
-- Name: Olympiad_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Olympiad_id_seq" OWNED BY public."Olympiad".id;


--
-- Name: Participant; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Participant" (
    id integer NOT NULL,
    surname character varying(100) NOT NULL,
    name character varying(50) NOT NULL,
    father_name character varying(50) NOT NULL,
    birthdate date NOT NULL
);


ALTER TABLE public."Participant" OWNER TO postgres;

--
-- Name: Participant_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Participant_id_seq" OWNER TO postgres;

--
-- Name: Participant_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Participant_id_seq" OWNED BY public."Participant".id;


--
-- Name: Sport_Type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sport_Type" (
    id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public."Sport_Type" OWNER TO postgres;

--
-- Name: Sport_Type_Olympiad; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sport_Type_Olympiad" (
    id integer NOT NULL,
    sport_type_id integer NOT NULL,
    olympiad_id integer NOT NULL
);


ALTER TABLE public."Sport_Type_Olympiad" OWNER TO postgres;

--
-- Name: Sport_Type_Olympiad_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Sport_Type_Olympiad_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Sport_Type_Olympiad_id_seq" OWNER TO postgres;

--
-- Name: Sport_Type_Olympiad_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sport_Type_Olympiad_id_seq" OWNED BY public."Sport_Type_Olympiad".id;


--
-- Name: Sport_Type_Participant; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Sport_Type_Participant" (
    id integer NOT NULL,
    sport_type_id integer NOT NULL,
    participant_id integer NOT NULL,
    gold_medals integer DEFAULT 0 NOT NULL,
    silver_medals integer DEFAULT 0 NOT NULL,
    bronze_medals integer DEFAULT 0 NOT NULL
);


ALTER TABLE public."Sport_Type_Participant" OWNER TO postgres;

--
-- Name: Sport_Type_Participant_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Sport_Type_Participant_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Sport_Type_Participant_id_seq" OWNER TO postgres;

--
-- Name: Sport_Type_Participant_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sport_Type_Participant_id_seq" OWNED BY public."Sport_Type_Participant".id;


--
-- Name: Sport_Type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Sport_Type_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Sport_Type_id_seq" OWNER TO postgres;

--
-- Name: Sport_Type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Sport_Type_id_seq" OWNED BY public."Sport_Type".id;


--
-- Name: Olympiad id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad" ALTER COLUMN id SET DEFAULT nextval('public."Olympiad_id_seq"'::regclass);


--
-- Name: Olympiad_Participant id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad_Participant" ALTER COLUMN id SET DEFAULT nextval('public."Olympiad_Participant_id_seq"'::regclass);


--
-- Name: Participant id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Participant" ALTER COLUMN id SET DEFAULT nextval('public."Participant_id_seq"'::regclass);


--
-- Name: Sport_Type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_id_seq"'::regclass);


--
-- Name: Sport_Type_Olympiad id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Olympiad" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_Olympiad_id_seq"'::regclass);


--
-- Name: Sport_Type_Participant id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Participant" ALTER COLUMN id SET DEFAULT nextval('public."Sport_Type_Participant_id_seq"'::regclass);


--
-- Data for Name: Olympiad; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Olympiad" (id, year, host_country, city, season) FROM stdin;
\.
COPY public."Olympiad" (id, year, host_country, city, season) FROM '$$PATH$$/4824.dat';

--
-- Data for Name: Olympiad_Participant; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Olympiad_Participant" (id, olympiad_id, participant_id) FROM stdin;
\.
COPY public."Olympiad_Participant" (id, olympiad_id, participant_id) FROM '$$PATH$$/4832.dat';

--
-- Data for Name: Participant; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Participant" (id, surname, name, father_name, birthdate) FROM stdin;
\.
COPY public."Participant" (id, surname, name, father_name, birthdate) FROM '$$PATH$$/4826.dat';

--
-- Data for Name: Sport_Type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sport_Type" (id, name) FROM stdin;
\.
COPY public."Sport_Type" (id, name) FROM '$$PATH$$/4828.dat';

--
-- Data for Name: Sport_Type_Olympiad; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sport_Type_Olympiad" (id, sport_type_id, olympiad_id) FROM stdin;
\.
COPY public."Sport_Type_Olympiad" (id, sport_type_id, olympiad_id) FROM '$$PATH$$/4830.dat';

--
-- Data for Name: Sport_Type_Participant; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Sport_Type_Participant" (id, sport_type_id, participant_id, gold_medals, silver_medals, bronze_medals) FROM stdin;
\.
COPY public."Sport_Type_Participant" (id, sport_type_id, participant_id, gold_medals, silver_medals, bronze_medals) FROM '$$PATH$$/4834.dat';

--
-- Name: Olympiad_Participant_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Olympiad_Participant_id_seq"', 1, false);


--
-- Name: Olympiad_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Olympiad_id_seq"', 1, false);


--
-- Name: Participant_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Participant_id_seq"', 1, false);


--
-- Name: Sport_Type_Olympiad_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Sport_Type_Olympiad_id_seq"', 1, false);


--
-- Name: Sport_Type_Participant_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Sport_Type_Participant_id_seq"', 1, false);


--
-- Name: Sport_Type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Sport_Type_id_seq"', 1, false);


--
-- Name: Olympiad_Participant Olympiad_Participant_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT "Olympiad_Participant_pkey" PRIMARY KEY (participant_id);


--
-- Name: Olympiad Olympiad_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad"
    ADD CONSTRAINT "Olympiad_pkey" PRIMARY KEY (id);


--
-- Name: Participant Participant_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Participant"
    ADD CONSTRAINT "Participant_pkey" PRIMARY KEY (id);


--
-- Name: Sport_Type_Olympiad Sport_Type_Olympiad_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "Sport_Type_Olympiad_pkey" PRIMARY KEY (id);


--
-- Name: Sport_Type_Participant Sport_Type_Participant_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT "Sport_Type_Participant_pkey" PRIMARY KEY (id);


--
-- Name: Sport_Type Sport_Type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type"
    ADD CONSTRAINT "Sport_Type_pkey" PRIMARY KEY (id);


--
-- Name: Sport_Type_Olympiad olymp_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "olymp_FK" FOREIGN KEY (olympiad_id) REFERENCES public."Olympiad"(id);


--
-- Name: Olympiad_Participant olympiad_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT olympiad_fk FOREIGN KEY (olympiad_id) REFERENCES public."Olympiad"(id);


--
-- Name: Olympiad_Participant participant_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Olympiad_Participant"
    ADD CONSTRAINT participant_fk FOREIGN KEY (participant_id) REFERENCES public."Participant"(id);


--
-- Name: Sport_Type_Participant participant_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT participant_id FOREIGN KEY (participant_id) REFERENCES public."Participant"(id);


--
-- Name: Sport_Type_Olympiad sport_type_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Olympiad"
    ADD CONSTRAINT "sport_type_FK" FOREIGN KEY (sport_type_id) REFERENCES public."Sport_Type"(id);


--
-- Name: Sport_Type_Participant sport_type_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Sport_Type_Participant"
    ADD CONSTRAINT sport_type_fk FOREIGN KEY (sport_type_id) REFERENCES public."Sport_Type"(id);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                