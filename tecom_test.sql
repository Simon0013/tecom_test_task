--
-- PostgreSQL database dump
--

-- Dumped from database version 15.4
-- Dumped by pg_dump version 15.3

-- Started on 2023-10-12 17:58:58

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
-- TOC entry 214 (class 1259 OID 49434)
-- Name: employee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employee (
    id bigint NOT NULL,
    name character varying(25) NOT NULL,
    surname character varying(50) NOT NULL,
    patronymic character varying(35),
    job_name character varying(100) NOT NULL,
    boss_id bigint
);


ALTER TABLE public.employee OWNER TO postgres;

--
-- TOC entry 3317 (class 0 OID 49434)
-- Dependencies: 214
-- Data for Name: employee; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employee (id, name, surname, patronymic, job_name, boss_id) FROM stdin;
\.


--
-- TOC entry 3173 (class 2606 OID 49438)
-- Name: employee employee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (id);


--
-- TOC entry 3174 (class 2606 OID 49439)
-- Name: employee employee_boss_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_boss_id_fkey FOREIGN KEY (boss_id) REFERENCES public.employee(id) NOT VALID;


-- Completed on 2023-10-12 17:58:58

--
-- PostgreSQL database dump complete
--

