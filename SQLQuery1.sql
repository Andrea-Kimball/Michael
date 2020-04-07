create table dbo.Era
(
EraId int not null identity(1,1) primary key,
EraName varchar(100)
);

create table dbo.Album
(
 AlbumId int not null identity(1,1) primary key,
 AlbumTitle varchar(100),
 AlbumDescription varchar(800),
 EraId int
);

create table dbo.Song
(
 SongId int not null identity(1,1) primary key,
 Title varchar(100),
 AlbumId int
);