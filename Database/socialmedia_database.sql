--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: hashtag; Type: TABLE; Schema: public; Owner: school_admin
--

CREATE TABLE public.hashtag (
    id bigint NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE public.hashtag OWNER TO school_admin;

--
-- Name: hashtag_id_seq; Type: SEQUENCE; Schema: public; Owner: school_admin
--

CREATE SEQUENCE public.hashtag_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hashtag_id_seq OWNER TO school_admin;

--
-- Name: hashtag_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: school_admin
--

ALTER SEQUENCE public.hashtag_id_seq OWNED BY public.hashtag.id;


--
-- Name: like; Type: TABLE; Schema: public; Owner: school_admin
--

CREATE TABLE public."like" (
    id bigint NOT NULL,
    post_id bigint NOT NULL,
    user_id bigint NOT NULL
);


ALTER TABLE public."like" OWNER TO school_admin;

--
-- Name: like_id_seq; Type: SEQUENCE; Schema: public; Owner: school_admin
--

CREATE SEQUENCE public.like_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.like_id_seq OWNER TO school_admin;

--
-- Name: like_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: school_admin
--

ALTER SEQUENCE public.like_id_seq OWNED BY public."like".id;


--
-- Name: post; Type: TABLE; Schema: public; Owner: school_admin
--

CREATE TABLE public.post (
    id bigint NOT NULL,
    type integer NOT NULL,
    user_id bigint NOT NULL,
    posted_at timestamp with time zone DEFAULT now() NOT NULL,
    description character varying(255)
);


ALTER TABLE public.post OWNER TO school_admin;

--
-- Name: post_hashtag; Type: TABLE; Schema: public; Owner: school_admin
--

CREATE TABLE public.post_hashtag (
    post_id bigint NOT NULL,
    hashtag_id bigint NOT NULL
);


ALTER TABLE public.post_hashtag OWNER TO school_admin;

--
-- Name: post_id_seq; Type: SEQUENCE; Schema: public; Owner: school_admin
--

CREATE SEQUENCE public.post_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.post_id_seq OWNER TO school_admin;

--
-- Name: post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: school_admin
--

ALTER SEQUENCE public.post_id_seq OWNED BY public.post.id;


--
-- Name: user; Type: TABLE; Schema: public; Owner: school_admin
--

CREATE TABLE public."user" (
    id bigint NOT NULL,
    user_name character varying(100) NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50),
    date_of_birth date NOT NULL,
    gender integer NOT NULL,
    mobile_number bigint NOT NULL,
    email_id character varying(255) NOT NULL,
    bio character varying(255),
    password character varying(50) NOT NULL
);


ALTER TABLE public."user" OWNER TO school_admin;

--
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: school_admin
--

CREATE SEQUENCE public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO school_admin;

--
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: school_admin
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- Name: hashtag id; Type: DEFAULT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.hashtag ALTER COLUMN id SET DEFAULT nextval('public.hashtag_id_seq'::regclass);


--
-- Name: like id; Type: DEFAULT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."like" ALTER COLUMN id SET DEFAULT nextval('public.like_id_seq'::regclass);


--
-- Name: post id; Type: DEFAULT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.post ALTER COLUMN id SET DEFAULT nextval('public.post_id_seq'::regclass);


--
-- Name: user id; Type: DEFAULT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- Data for Name: hashtag; Type: TABLE DATA; Schema: public; Owner: school_admin
--

COPY public.hashtag (id, name) FROM stdin;
1	string
2	Latest
3	RIP
4	Cool
5	Wow
6	MindBlow
7	string
\.


--
-- Data for Name: like; Type: TABLE DATA; Schema: public; Owner: school_admin
--

COPY public."like" (id, post_id, user_id) FROM stdin;
2	2	2
3	2	5
4	2	6
5	4	1
6	4	2
8	4	6
13	4	5
\.


--
-- Data for Name: post; Type: TABLE DATA; Schema: public; Owner: school_admin
--

COPY public.post (id, type, user_id, posted_at, description) FROM stdin;
2	2	2	2022-03-14 23:37:09.134036+05:30	Enjoyed
3	1	5	2022-03-15 03:33:05.536595+05:30	Huhu
4	2	1	2022-03-15 03:34:44.501367+05:30	Enjoy
5	1	1	2022-03-15 05:17:10.399288+05:30	string
\.


--
-- Data for Name: post_hashtag; Type: TABLE DATA; Schema: public; Owner: school_admin
--

COPY public.post_hashtag (post_id, hashtag_id) FROM stdin;
2	4
4	4
3	1
3	4
\.


--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: school_admin
--

COPY public."user" (id, user_name, first_name, last_name, date_of_birth, gender, mobile_number, email_id, bio, password) FROM stdin;
1	sanjaymadari	Sanjay	Madari	1992-12-02	2	9666886540	sanjaymadari@gmail.com	Keep Quiet	Sanju@2
2	nareshpatel	Naresh	P	1996-07-01	2	7898123456	naresh@gmail.com	Leave Life Happy	Nari@123
5	nithinappy	Nithin	B	1998-07-24	2	9876543220	nithin@gmail.com	Make It Happen	Appy@123
6	randy	Ranadeep	M	1999-01-01	2	7654321098	ranadeep@gmail.com	Do it today	Rana@123
7	ravs	Ravalika	M	2000-03-07	1	9989624473	ravalika@gmail.com	Dont Care At All	Ravalika@7
8	raghu	Sriram	M	2003-04-11	2	9898989898	sriram@gmail.com	Mr Perfect	Sriram
\.


--
-- Name: hashtag_id_seq; Type: SEQUENCE SET; Schema: public; Owner: school_admin
--

SELECT pg_catalog.setval('public.hashtag_id_seq', 7, true);


--
-- Name: like_id_seq; Type: SEQUENCE SET; Schema: public; Owner: school_admin
--

SELECT pg_catalog.setval('public.like_id_seq', 13, true);


--
-- Name: post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: school_admin
--

SELECT pg_catalog.setval('public.post_id_seq', 5, true);


--
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: school_admin
--

SELECT pg_catalog.setval('public.user_id_seq', 8, true);


--
-- Name: user email_id; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT email_id UNIQUE (email_id);


--
-- Name: hashtag hashtag_pkey; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.hashtag
    ADD CONSTRAINT hashtag_pkey PRIMARY KEY (id);


--
-- Name: like like_pkey; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."like"
    ADD CONSTRAINT like_pkey PRIMARY KEY (id);


--
-- Name: user mobile_number; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT mobile_number UNIQUE (mobile_number);


--
-- Name: post post_pkey; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT post_pkey PRIMARY KEY (id);


--
-- Name: user user_name; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_name UNIQUE (user_name);


--
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- Name: post_hashtag hashtag_id; Type: FK CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.post_hashtag
    ADD CONSTRAINT hashtag_id FOREIGN KEY (hashtag_id) REFERENCES public.hashtag(id) NOT VALID;


--
-- Name: post_hashtag post_id; Type: FK CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.post_hashtag
    ADD CONSTRAINT post_id FOREIGN KEY (post_id) REFERENCES public.post(id) NOT VALID;


--
-- Name: like post_id; Type: FK CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."like"
    ADD CONSTRAINT post_id FOREIGN KEY (post_id) REFERENCES public.post(id) NOT VALID;


--
-- Name: post user_id; Type: FK CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- Name: like user_id; Type: FK CONSTRAINT; Schema: public; Owner: school_admin
--

ALTER TABLE ONLY public."like"
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public."user"(id) NOT VALID;


--
-- PostgreSQL database dump complete
--

