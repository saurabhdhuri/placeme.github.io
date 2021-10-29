USE [master]
GO

/****** Object:  Database [PlaceMe]    Script Date: 29-10-2021 05:21:20 PM ******/
CREATE DATABASE [PlaceMe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PlaceMe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PlaceMe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PlaceMe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PlaceMe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PlaceMe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PlaceMe] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PlaceMe] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PlaceMe] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PlaceMe] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PlaceMe] SET ARITHABORT OFF 
GO

ALTER DATABASE [PlaceMe] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [PlaceMe] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PlaceMe] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PlaceMe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PlaceMe] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PlaceMe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PlaceMe] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PlaceMe] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PlaceMe] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PlaceMe] SET  ENABLE_BROKER 
GO

ALTER DATABASE [PlaceMe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PlaceMe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PlaceMe] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PlaceMe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PlaceMe] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PlaceMe] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PlaceMe] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PlaceMe] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PlaceMe] SET  MULTI_USER 
GO

ALTER DATABASE [PlaceMe] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PlaceMe] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PlaceMe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PlaceMe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PlaceMe] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PlaceMe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [PlaceMe] SET QUERY_STORE = OFF
GO

ALTER DATABASE [PlaceMe] SET  READ_WRITE 
GO

