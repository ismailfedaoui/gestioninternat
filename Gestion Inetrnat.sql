create database gestion_internat
go

use gestion_internat
go

--creation des tables
create table filiere(id_filiere int primary key , nom_filiere varchar(65)  not null, Groupe varchar(9), niveau varchar(30),annee varchar(30))
create table Emploi(jour varchar(30)  not null,am00 varchar(60) default 'Detoir',am01 varchar(60) default 'Detoir',am02 varchar(60) default 'Detoir',am03 varchar(60) default 'Detoir',am04 varchar(60) default 'Detoir',am05 varchar(60) default 'Detoir',am06 varchar(60) default 'Detoir',am07 varchar(60) default 'Repas',am08 varchar(60) default 'Detoir',am09 varchar(60) default 'Detoir',am10 varchar(60) default 'Detoir',am11 varchar(60) default 'Detoir',pm12 varchar(60) default 'Repas',m13 varchar(60) default 'Detoir',pm14 varchar(60) default 'Detoir',pm15 varchar(60) default 'Detoir',pm16 varchar(60) default 'Detoir',pm17 varchar(60) default 'Detoir',pm18 varchar(60) default 'Detoir',pm19 varchar(60) default 'Detoir',pm20 varchar(60) default 'Repas',pm21 varchar(60) default 'Detoir',pm22 varchar(60) default 'Detoir',pm23 varchar(60) default 'Detoir',#id_filiere int foreign key references filiere(id_filiere) on delete cascade on update cascade)
create table directeur(id_directeur int primary key ,nom varchar(30) not null,prenom varchar(30) not null,pseudo varchar(30) not null unique,mdp varchar(30) not null,photo image,date_derniere_log date,telephone varchar(15))
create table gestionnaire (id_gest int identity primary key,nom varchar(30) not null,prenom varchar(30) not null,sexe varchar(10) check(sexe in ('homme' ,'femme')) not null,telephone varchar(15),pseudo varchar(30) not null  unique,mdp varchar(30) not null,photo image,date_debut_utilisation date,date_derniere_log date, #id_directeur int foreign key references directeur(id_directeur) on delete cascade on update  cascade, autorisé varchar(10),numreçu_a_modifier varchar (60))
create table contribution(num_contribution int primary key,mois varchar(10) not null )
create table detoir(id_detoir char(1) primary key check(id_detoir in ('A','B','C','D')))
create table buanderie(id_buanderie int primary key  ,#id_detoir char(1) not null foreign key references detoir(id_detoir) on delete cascade on update  cascade,num_lit tinyint not null check(num_lit in (1,2)),num_armoire tinyint not null check(num_armoire in (1,2)))
create table chambre (id_chambre varchar(20)  primary key ,num_chambre tinyint not null check(num_chambre in (0,1,2,3,4,5,6,7,8)),num_lit tinyint not null check(num_lit in (1,2,3,4)),num_armoire tinyint not null,#id_detoir char(1) not null foreign key references detoir(id_detoir) on delete cascade on update  cascade)
create table stagiaire (cfe bigint   primary key,nom varchar(40) not null,prenom varchar(40) not null,datenaissance date not null ,sexe varchar(10)  not null,telephone varchar(15) ,Rue varchar(150) not null,ville varchar(30) not null,cp int  not null,nationalité varchar(40) not null,type_stagiaire varchar(30)  not null ,photo image,QR_code image  , nom_respo varchar(40), prenom_respo varchar(40),tel_respo varchar(15),lien varchar(20) ,sexe_respo varchar(10) ,#id_filiere int  foreign key references filiere(id_filiere) on update cascade on delete set null,#id_chambre varchar(20)  foreign key references chambre(id_chambre) , #id_buanderie int  foreign key references buanderie(id_buanderie) ,carte image,date_insc date)
create table respo_chambre (date_debut_resp date,#cfe bigint foreign key references stagiaire(cfe) on delete cascade on update  cascade,#id_chambre varchar(20)  foreign key references chambre(id_chambre) on delete cascade on update cascade,#id_detoir char(1) foreign key references detoir(id_detoir))
create table stagiaire_gestionnaire (date_gestion date, type_gestion varchar(100),#cfe bigint foreign key references stagiaire(cfe) on delete cascade on update  cascade,#id_gest int foreign key references gestionnaire(id_gest) )
create table reçu(num_reçu varchar(25)  primary key,date_paiement date not null ,montant int not null,pension varchar(20) not null ,#cfe bigint not null foreign key references stagiaire(cfe) on delete cascade on update  cascade,nbr_mois int) 
create table contribution_reçu(#num_contribution int foreign key references contribution(num_contribution) on delete cascade on update cascade,#num_reçu varchar(25) foreign key references reçu (num_reçu) on delete cascade on update  cascade)
create table absence(num_abs int identity  primary key,type_abs  varchar(30) not null,date_abs date,description_abs varchar(60),heure_abs time not null,justification_abs varchar(100),#id_gest int  not null foreign key references gestionnaire(id_gest) on delete cascade on update  cascade,#cfe bigint  not null foreign key references stagiaire(cfe) on delete cascade on update cascade)
create table sanction(num_sanc int identity  primary key,type_sanc varchar(100) not null,motif_sanc varchar(200) not null,date_sanc date  not null,duree_sanc int,#id_gest int  not null foreign key references gestionnaire(id_gest) on delete cascade on update  cascade,#cfe bigint not null foreign key references stagiaire(cfe) on delete cascade on update  cascade)
create table autorisation (num_autorisation int identity  primary key,type_autorisation varchar(60) not null,description_autorisation varchar(150)  not null,heure_autorisation time  not null,duree_autorisation int ,#id_gest int  not null foreign key references gestionnaire(id_gest) on delete cascade on update  cascade,#cfe bigint  not null foreign key references stagiaire(cfe) on delete cascade on update  cascade,date_autorisation date) 
go

insert into directeur(id_directeur,nom,prenom,pseudo,mdp) values(1,'Ismail','Fedaoui','ismailfedaoui','P@ssw0rd1')
insert into contribution values(9,'Septembre'),(10,'Octobre'),(11,'Novembre'),(12,'Décembre'),(1,'Janvier'),(2,'Février'),(3,'Mars'),(4,'Avril'),(5,'Mai'),(6,'Juin')
insert into detoir values('A'),('B'),('C'),('D')
go

--creation ps pour la cx de gest
create proc connexion_gest @user varchar(30),@mdp varchar(30)
as
begin
if exists(select * from gestionnaire where pseudo=@user  )
begin
if exists(select * from gestionnaire where pseudo=@user and mdp=@mdp)
return 1
else 
return 2
end
else 
return 0
end
go

--creation ps pour la cx de dir
create proc connexion_dir @user varchar(30),@mdp varchar(30)
as
begin
if exists(select * from directeur where pseudo=@user  )
begin
if exists(select * from directeur where pseudo=@user and mdp=@mdp)
return 1
else 
return 2
end
else 
return 0
end
go

-- ajout de filiére
create proc sp_nouvel_emploi @nom_fl varchar(30),@groupe varchar(30),@niveau varchar(30),@anne varchar(40)
as
begin
insert into filiere values((select count(id_filiere) from filiere )+1,@nom_fl,@groupe,@niveau,@anne)
insert into Emploi values('Lundi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
insert into Emploi values('Mardi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
insert into Emploi values('Mercredi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
insert into Emploi values('Jeudi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
insert into Emploi values('Vendredi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
insert into Emploi values('Samedi',default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,default,(select max(id_filiere) from filiere ))
select jour,am09,am10,am11,pm12,m13,pm14,pm15,pm16,pm17,pm18 from emploi where #id_filiere=(select max(id_filiere) from filiere )
end
go


create view v_ajouter_stg (cfe,nom,prenom,datenaissance,sexe,telephone,rue,ville,cp,nationalité,type_stagiaire,photo,qr_code,nom_respo,prenom_respo,tel_respo,lien,sexe_respo,#id_filiere,carte,num_chambre,c_num_lit,c_num_armoire,#id_detoir,id_buanderie,b_num_lit,b_num_armoire,#id_gest,pension)
as
select cfe,nom,prenom,datenaissance,sexe,telephone,rue,ville,cp,nationalité,type_stagiaire,photo,qr_code,nom_respo,prenom_respo,tel_respo,lien,sexe_respo,#id_filiere,carte,num_chambre,chambre.num_lit,chambre.num_armoire,chambre.#id_detoir,id_buanderie,buanderie.num_lit,buanderie.num_armoire,#id_gest,pension from stagiaire join reçu on stagiaire.cfe=reçu.#cfe full outer join chambre on stagiaire.#id_chambre=chambre.id_chambre join buanderie on stagiaire.#id_buanderie=buanderie.id_buanderie join stagiaire_gestionnaire on stagiaire.cfe=stagiaire_gestionnaire.#cfe
go

create trigger t1 on v_ajouter_stg
instead of insert
as
if (select pension from inserted) ='Complete'
begin
if (select id_buanderie from inserted) =0
begin 
insert into chambre values(((select COUNT(id_chambre) from chambre)+1),(select num_chambre from inserted),(select c_num_lit from inserted),(select c_num_armoire from inserted),(select #id_detoir from inserted))
insert into stagiaire values((select cfe from inserted),(select nom from inserted),(select prenom from inserted),(select datenaissance from inserted),(select sexe from inserted),(select telephone from inserted),(select rue from inserted),(select ville from inserted),(select cp from inserted),(select nationalité from inserted),
(select type_stagiaire from inserted),(select photo from inserted),(select qr_code from inserted),(select nom_respo from inserted),(select prenom_respo from inserted),(select tel_respo from inserted),(select lien from inserted),(select sexe_respo from inserted),(select #id_filiere from inserted  ),
((select max(id_chambre) from chambre)),null,(select carte from inserted),getdate())
end
else 
begin
insert into buanderie values(((select max(id_buanderie) from buanderie)+1),(select #id_detoir from inserted),(select b_num_lit from inserted),(select b_num_armoire from inserted))
insert into stagiaire values((select cfe from inserted),(select nom from inserted),(select prenom from inserted),(select datenaissance from inserted),(select sexe from inserted),(select telephone from inserted),(select rue from inserted),(select ville from inserted),(select cp from inserted),(select nationalité from inserted),
(select type_stagiaire from inserted),(select photo from inserted),(select qr_code from inserted),(select nom_respo from inserted),(select prenom_respo from inserted),(select tel_respo from inserted),(select lien from inserted),(select sexe_respo from inserted),(select #id_filiere from inserted  ),
null,(select #id_detoir from inserted ),(select carte from inserted),getdate())
end
end 
else 
begin
insert into stagiaire values((select cfe from inserted),(select nom from inserted),(select prenom from inserted),(select datenaissance from inserted),(select sexe from inserted),(select telephone from inserted),(select rue from inserted),(select ville from inserted),(select cp from inserted),(select nationalité from inserted),
(select type_stagiaire from inserted),(select photo from inserted),(select qr_code from inserted),(select nom_respo from inserted),(select prenom_respo from inserted),(select tel_respo from inserted),(select lien from inserted),(select sexe_respo from inserted),(select #id_filiere from inserted  ),
null,null,(select carte from inserted),getdate())
end
insert into stagiaire_gestionnaire values(getdate(),'ajout avec nouveau paiement',(select cfe from inserted),(select #id_gest from inserted))
go



create proc rechercher_autorisation @cfe varchar(30) , @date1 varchar(60)  , @date2 varchar(60),@mois varchar(20),@group_fl varchar(30),@nom_fl varchar(60)
as
begin
if @cfe ='' set @cfe='%'
if @group_fl='Tous' set @group_fl='%'
if @nom_fl='Tous' set @nom_fl='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
select  @date_ins = '1/9/'+datename(year,getdate())
else
select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if @mois =''
begin
if @date1 ='' set @date1='%'
if @date2 ='' set @date2='%'					   
select #cfe , s.prenom, s.nom,type_autorisation,description_autorisation ,date_autorisation,heure_autorisation,duree_autorisation,g.prenom+' '+g.nom from autorisation a inner join stagiaire s on a.#cfe=s.cfe inner join gestionnaire g on a.#id_gest=g.id_gest join filiere on s.#id_filiere=id_filiere where date_insc between @date_ins and GETDATE()  and cast(#cfe as varchar) like @cfe and date_autorisation between @date1 and @date2 and Groupe like @group_fl and nom_filiere like @nom_fl
end
else 
begin
if @mois ='Tous' set @mois='%'
select cfe ,s.prenom, s.nom,type_autorisation,description_autorisation ,date_autorisation,heure_autorisation,duree_autorisation,g.prenom+' '+g.nom from autorisation a join stagiaire s on a.#cfe=s.cfe join gestionnaire g on a.#id_gest=g.id_gest join filiere on s.#id_filiere=id_filiere where date_insc between @date_ins and GETDATE() and cast(#cfe as varchar) like @cfe and cast(datepart(month,date_autorisation)as varchar) like @mois  and Groupe like @group_fl and nom_filiere like @nom_fl
end
end
go


create proc controler_abs @type varchar(40),@detoir varchar(30),@chambre varchar(30),@buanderie int , @nom_fl varchar(60),@group_fl varchar(30)
as
begin
if @detoir ='Tous' set @detoir='%'
if @type ='Tous' set @type='%'
if @type ='Detoir' set @type='Complete'
if @type ='Repas' set @type='Demi pension'
if @chambre ='Tous' set @chambre='%'
if @nom_fl ='Tous' set @nom_fl='%'
if @group_fl ='Tous' set @group_fl='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
                       select  @date_ins = '1/9/'+datename(year,getdate())
else
                       select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if(@buanderie=1)
begin
if @type='Complete'
select  prenom+' '+nom as nmcomp,cfe as cfe ,sexe as sexe from stagiaire join filiere on filiere.id_filiere=stagiaire.#id_filiere full outer join buanderie on stagiaire.#id_buanderie=buanderie.id_buanderie join reçu on stagiaire.cfe=reçu.#cfe where date_insc between @date_ins and GETDATE() and buanderie.#id_detoir like @detoir and pension like @type and Groupe like @group_fl and nom_filiere like @nom_fl
else
select  prenom+' '+nom as nmcomp,cfe as cfe ,sexe as sexe from stagiaire join filiere on filiere.id_filiere=stagiaire.#id_filiere full outer join buanderie on stagiaire.#id_buanderie=buanderie.id_buanderie join reçu on stagiaire.cfe=reçu.#cfe where date_insc between @date_ins and GETDATE() and pension like @type and Groupe like @group_fl and nom_filiere like @nom_fl
end
else
begin
if @type='Complete'
select prenom+' '+nom as nmcomp,cfe as cfe ,sexe as sexe from stagiaire join filiere on filiere.id_filiere=stagiaire.#id_filiere full outer join chambre on stagiaire.#id_chambre=chambre.id_chambre join reçu on stagiaire.cfe=reçu.#cfe where date_insc between @date_ins and GETDATE() and cast(chambre.num_chambre as varchar)  like @chambre and chambre.#id_detoir like @detoir and pension like @type and Groupe like @group_fl and nom_filiere like @nom_fl
else
select prenom+' '+nom as nmcomp,cfe as cfe ,sexe as sexe from stagiaire join filiere on filiere.id_filiere=stagiaire.#id_filiere full outer join chambre on stagiaire.#id_chambre=chambre.id_chambre join reçu on stagiaire.cfe=reçu.#cfe where date_insc between @date_ins and GETDATE() and pension like @type and Groupe like @group_fl and nom_filiere like @nom_fl
end
end
go

create proc rechercher_abs @type varchar(40) ,@nom_fl varchar(60),@group_fl varchar(30),@mois varchar(30),@d1 varchar(60),@d2 varchar(60)
as
begin
if @type ='Tous' set @type='%'
if @group_fl ='Tous' set @group_fl='%'
if @nom_fl ='Tous' set @nom_fl='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
                       select  @date_ins = '1/9/'+datename(year,getdate())
                    else
                       select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if @mois=''
begin
if @d1=''set @d1='%'
if @d2=''set @d2='%'
select  num_abs,cfe as CFE,stagiaire.prenom+' '+stagiaire.nom as 'Nom Complet' ,stagiaire.sexe as Sexe,type_abs as 'Type d''absence',date_abs as 'Date',heure_abs as Heure, description_abs as 'Description',gestionnaire.prenom+' '+gestionnaire.nom as 'Par le gestionnaire' from absence join gestionnaire on gestionnaire.id_gest=absence.#id_gest join stagiaire on stagiaire.cfe=absence.#cfe join filiere on filiere.id_filiere=stagiaire.#id_filiere where date_insc between @date_ins and GETDATE() and type_abs like @type and Groupe like @group_fl and nom_filiere like @nom_fl and date_abs between @d1 and @d2 
end
else
begin
if @mois = 'Tous' set @mois = '%'
select  num_abs,cfe as CFE,stagiaire.prenom+' '+stagiaire.nom as 'Nom Complet' ,stagiaire.sexe as Sexe,type_abs as 'Type d''absence',date_abs as 'Date',heure_abs as Heure, description_abs as 'Description',gestionnaire.prenom+' '+gestionnaire.nom as 'Par le gestionnaire' from absence join gestionnaire on gestionnaire.id_gest=absence.#id_gest join stagiaire on stagiaire.cfe=absence.#cfe join filiere on filiere.id_filiere=stagiaire.#id_filiere where date_insc between @date_ins and GETDATE() and type_abs like @type and Groupe like @group_fl and nom_filiere like @nom_fl and cast (datepart(month,date_abs) as varchar) like @mois
end
end
go

create proc rechercher_sanction @cfe varchar(30) , @date1 varchar(60)  , @date2 varchar(60),@mois varchar(10),@group_fl varchar(30),@nom_fl varchar(60)
as
begin
if @cfe ='' set @cfe='%'
if @group_fl ='Tous' set @group_fl='%'
if @nom_fl ='Tous' set @nom_fl='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
select  @date_ins = '1/9/'+datename(year,getdate())
else
select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if @mois =''
begin
if @date1 ='' set @date1='%'
if @date2 ='' set @date2='%'
select #cfe , s.prenom, s.nom,type_sanc,motif_sanc ,date_sanc,duree_sanc,g.prenom+' '+g.nom from sanction sa inner join stagiaire s on sa.#cfe=s.cfe inner join gestionnaire g on sa.#id_gest=g.id_gest join filiere on s.#id_filiere=id_filiere where date_insc between @date_ins and GETDATE()  and cast(#cfe as varchar) like @cfe and date_sanc between @date1 and @date2  and groupe like @group_fl and nom_filiere like @nom_fl
end
else 
begin
if @mois ='Tous' set @mois='%'
select #cfe , s.prenom, s.nom,type_sanc,motif_sanc ,date_sanc,duree_sanc,g.prenom+' '+g.nom from sanction sa inner join stagiaire s on sa.#cfe=s.cfe inner join gestionnaire g on sa.#id_gest=g.id_gest join filiere on s.#id_filiere=id_filiere where date_insc between @date_ins and GETDATE()  and cast(#cfe as varchar) like @cfe  and cast(datepart(month,date_sanc) as varchar) like @mois  and groupe like @group_fl and nom_filiere like @nom_fl
end
end
go

create proc rechercher_stagiaire @type varchar(30) ,@pension varchar(60),@sexe varchar(40),@detoir varchar(4),@chambre varchar(7), @date1 varchar(60)  , @date2 varchar(60),@mois varchar(10),@group_fl varchar(30),@nom_fl varchar(60),@buanderie int
as
begin 
if @type ='Tous' set @type='%'
if @pension ='Tous' set @pension='%'
if @detoir ='Tous' set @detoir='%'
if @chambre ='Tous' set @chambre='%'
if @group_fl ='Tous' set @group_fl='%'
if @nom_fl ='Tous' set @nom_fl='%'
if @sexe ='Tous' set @sexe='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
select  @date_ins = '1/9/'+datename(year,getdate())
else
select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if @buanderie=0
begin
if @mois =''
begin
if @pension='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir is null  and cast(chambre.num_chambre as varchar) is null  and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir like @detoir  and cast(chambre.num_chambre as varchar) like @chambre and reçu.pension like 'Complete' and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like '%' and groupe like @group_fl and nom_filiere like @nom_fl
end
else 
begin
if @mois = 'Tous' set @mois='%'
begin
if @pension='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir is null  and cast(chambre.num_chambre as varchar) is null and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir like @detoir  and cast(chambre.num_chambre as varchar) like @chambre  and reçu.pension like 'Complete' and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like '%' and groupe like @group_fl and nom_filiere like @nom_fl
end
end
end
else
begin
if @mois = ''
begin
if @pension='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir is null and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir like @detoir and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
else 
begin
if @mois ='Tous' set @mois='%'
begin
if @pension='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir is null and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir like @detoir  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',s.telephone as Téléphone,s.Rue+' '+ville+' '+cast(cp as varchar) as Adresse,date_insc as 'Date d''inscription',g.prenom+' '+g.nom 'Ajouté par' from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe where date_insc between @date_ins and GETDATE()  and cast(datepart(month,s.date_insc) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
end
end
end
go

create proc rechercher_contribution @type varchar(30) ,@pension varchar(60),@sexe varchar(40),@detoir varchar(4),@chambre varchar(7), @date1 varchar(60)  , @date2 varchar(60),@mois varchar(10),@group_fl varchar(30),@nom_fl varchar(60),@buanderie int
as
begin 
if @type ='Tous' set @type='%'
if @pension ='Tous' set @pension='%'
if @detoir ='Tous' set @detoir='%'
if @chambre ='Tous' set @chambre='%'
if @group_fl ='Tous' set @group_fl='%'
if @nom_fl ='Tous' set @nom_fl='%'
if @sexe ='Tous' set @sexe='%'
declare @date_ins date
if month(getdate()) = 9 or month(getdate()) = 10 or month(getdate()) = 11 or month(getdate()) = 12
select  @date_ins = '1/9/'+datename(year,getdate())
else
select  @date_ins = '1/9/'+datename(year,dateadd(year,-1,getdate()))
if @buanderie=0
begin
if @mois =''
begin
if @pension ='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir like @detoir  and cast(chambre.num_chambre as varchar) like @chambre and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension ='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
else
begin
if @mois = 'Tous' set @mois='%'
begin
if @pension ='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and chambre.#id_detoir like @detoir  and cast(chambre.num_chambre as varchar) like @chambre  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
if @pension ='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join chambre on chambre.id_chambre=s.#id_chambre join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
end
end
else
begin
if @mois = ''
begin
if @pension ='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir like @detoir and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension ='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else 
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where reçu.date_paiement between @date1 and @date2 and s.sexe like @sexe and s.type_stagiaire like @type and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
begin
if @mois ='Tous' set @mois='%'
begin
if @pension ='Complete'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type and buanderie.#id_detoir like @detoir  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else if @pension ='Demi pension'
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
else
select distinct s.cfe as CFE , s.prenom +' '+ s.nom as 'Nom Complet',date_insc as 'Date d''inscription',pension,contribution.mois from  stagiaire s  join stagiaire_gestionnaire sg on s.cfe=sg.#cfe join gestionnaire g on g.id_gest=sg.#id_gest join filiere on s.#id_filiere=id_filiere full outer join buanderie on buanderie.id_buanderie=s.#id_buanderie join reçu on reçu.#cfe=s.cfe join contribution_reçu on reçu.num_reçu =contribution_reçu.#num_reçu join contribution on contribution.num_contribution=contribution_reçu.#num_contribution where date_insc between @date_ins and GETDATE()  and cast(datepart(month,reçu.date_paiement) as varchar) like @mois and s.sexe like @sexe and s.type_stagiaire like @type  and reçu.pension like @pension and groupe like @group_fl and nom_filiere like @nom_fl
end
end
end
end
go












