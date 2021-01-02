alter session set "_oracle_script"=true;
create user hospital_dba identified by p1234567;
grant all privileges to hospital_dba;
grant dba to hospital_dba;

create user gate_keeper identified by p1234567;
grant create session to gate_keeper;