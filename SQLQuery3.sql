create table dbo.Eras
(
EraId int not null identity(1,1) primary key,
EraName varchar(100)
);

create table dbo.Albums
(
 AlbumId int not null identity(1,1) primary key,
 AlbumTitle varchar(100),
 AlbumDescription varchar(800),
 EraId int
);

create table dbo.Songs
(
 SongId int not null identity(1,1) primary key,
 Title varchar(100),
 AlbumId int
);