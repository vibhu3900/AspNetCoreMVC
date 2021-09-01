
create table admindetails(Admin_Id Integer Identity(100,1) primary key,Admin_Name varchar(50),
Admin_Password varchar(50),Admin_Email varchar(50),Admin_Phoneno varchar(50));

select * from admindetails;


drop table admindetails

insert into admindetails values('Saburi','Saburi123','saburi@example.com',9897990099)
insert into admindetails values('Sai','Sai123','sai@example.com',9027778899)