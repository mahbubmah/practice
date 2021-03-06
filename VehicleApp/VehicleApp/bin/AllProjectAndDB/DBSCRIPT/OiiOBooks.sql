USE [master]
GO
/****** Object:  Database [OiiOBook]    Script Date: 6/23/2015 12:46:38 PM ******/
CREATE DATABASE [OiiOBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OiiOBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OiiOBook.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OiiOBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OiiOBook_log.ldf' , SIZE = 47616KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OiiOBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OiiOBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OiiOBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OiiOBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OiiOBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OiiOBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OiiOBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [OiiOBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OiiOBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [OiiOBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OiiOBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OiiOBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OiiOBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OiiOBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OiiOBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OiiOBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OiiOBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OiiOBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OiiOBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OiiOBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OiiOBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OiiOBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OiiOBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OiiOBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OiiOBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OiiOBook] SET RECOVERY FULL 
GO
ALTER DATABASE [OiiOBook] SET  MULTI_USER 
GO
ALTER DATABASE [OiiOBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OiiOBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OiiOBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OiiOBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OiiOBook', N'ON'
GO
USE [OiiOBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromMyFvrt]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Asiful Islam>
-- Create date: <3/31/2015,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteFromMyFvrt] 
	-- Add the parameters for the stored procedure here
	(
	@id bigint
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from MyFavourites where IID=@id;
	
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteFromUserGroup]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Asiful Islam>
-- Create date: <3/11/2015,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFromUserGroup] 
	-- Add the parameters for the stored procedure here
	(
	@id bigint
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete from UserGroup where IID=@id;
	
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllFromPostOffice]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Asiful Islam>
-- Create date: <2/24/2015 >

CREATE PROC [dbo].[GetAllFromPostOffice]
As

BEGIN TRY 

-- Retrieve column specific information 

	SELECT PstOffice.IID, PstOffice.Code, PstOffice.Name,PstOffice.IsRemoved, country.Name CountryName, division.Name DivisionOrState, district.Name  District,plcStation.Name PoliceStationName from PostOffice PstOffice
	left join PoliceStation plcStation ON PstOffice.PoliceStationID=plcStation.IID
	join District district ON PstOffice.DistrictID=district.IID
	join DivisionOrState division ON division.IID=PstOffice.DivisionOrStateID
	join Country country ON country.IID=PstOffice.CountryID
	--WHERE country.IsRemoved=0 and PstOffice.IsRemoved=0 and plcStation.IsRemoved=0 and district.IsRemoved=0 and division.IsRemoved=0


END TRY


BEGIN CATCH
	--goto ErrHandler
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[GetAllLocation]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Asiful Islam>
-- Create date: <2/24/2015 >

CREATE PROC [dbo].[GetAllLocation]
As

BEGIN TRY 

-- Retrieve column specific information 

	SELECT loc.IID, country.Name Country, district.Name District ,plcStation.Name PoliceStation,post.Name PostOffice, loc.CurrentLocation Location from Location loc
	left join PoliceStation plcStation ON loc.PoliceStationID=plcStation.IID
	join District district ON loc.DistrictID =district.IID
	join Country country ON loc.CountryID=country.IID
	join PostOffice post ON loc.PostOfficeID=post.IID
	WHERE loc.IsRemove=0 


END TRY


BEGIN CATCH
	--goto ErrHandler
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[GetMapCategory]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMapCategory]
(	
	@categoryID	bigint	
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	  SELECT 
	  CAT.IID as CatID,
	  MAPTBL.Name as MapName	  


	 FROM MappingCategory MAPCAT
	 INNER JOIN Category CAT ON MAPCAT.CategoryID=CAT.IID	
	 INNER JOIN MappingTable MAPTBL ON MAPCAT.MappingTableID=MAPTBL.IID
	 

	 WHERE CAT.IsRemoved='false' AND MAPCAT.IsRemoved='false' AND MAPTBL.IsRemoved='false' AND CAT.IID=@categoryID
	 

	 END	 

END


GO
/****** Object:  StoredProcedure [dbo].[GetSearchResultForRegisteredUser]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Asiful Islam>
-- Create date: <03.03.2015,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSearchResultForRegisteredUser] 
	-- Add the parameters for the stored procedure here
	(
	
	@email nvarchar(250),
	@startDate datetime,
	@enddate datetime,
	@SetMaxDAte datetime
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS(select * from AdGiver where CONVERT(VARCHAR(10),CreatedDate,101)=CONVERT(VARCHAR(10),@startDate,101))
	 select @SetMaxDAte=(select CONVERT(VARCHAR(10),MAX(CreatedDate),101) as LastDate from AdGiver)
    BEGIN

	 SELECT  IID,
			 Name,
			 NationalID,
			 EmailID,
			 CreatedDate,
			 IsVerified

	 FROM    AdGiver
	 WHERE 
	   
			(@email IS NULL OR AdGiver.EmailID like RTRIM (@email) + '%') 
			 AND (@startDate IS NULL OR  CONVERT(VARCHAR(10),CreatedDate,101)>=CONVERT(VARCHAR(10),@startDate,101)) 
			 AND (@enddate IS NULL OR CONVERT(VARCHAR(10),CreatedDate,101)<=CONVERT(VARCHAR(10),@enddate,101) )


	 END	 
	
END


GO
/****** Object:  StoredProcedure [dbo].[GetServerDateTime]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetServerDateTime] 
AS
BEGIN
SET NOCOUNT ON;   
   SELECT  GETDATE() as DateTimeOfServer;
END







GO
/****** Object:  StoredProcedure [dbo].[InsertBookFeatureChildXML]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertBookFeatureChildXML]
(	
	@BookXML ntext 
) 

AS
  DECLARE @docHandle int, @BookID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @BookXML
  
  BEGIN TRANSACTION--------------
  
  --------Insert Book Table --------

  INSERT INTO Book
  (
		Edition,
		[CategoryID],
		[Size],
		[ISBN],
		[BookTitle],
		[BookWishTypeID],
		[AuthorID],
		[PublisherID],
		[Abstract],
		[Price],
		[LastVisibilityDate],
		[NumberOfUsersRate],
		[AvgRating],
		[PublishedDate],
		[ImageUrl],
		[VAT],
		[Version],
		[Discount],
		[Quantity],
		[IsLatest],
		[IsRecommended],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[TotalVisit],
		[IsRemoved]
 )
 
  SELECT 
	   Edition,
		[CategoryID],
		[Size],
		[ISBN],
		[BookTitle],
		[BookWishTypeID],
		[AuthorID],
		[PublisherID],
		[Abstract],
		[Price],
		[LastVisibilityDate],
		[NumberOfUsersRate],
		[AvgRating],
		[PublishedDate],
		[ImageUrl],
		[VAT],
		[Version],
		[Discount],
		[Quantity],
		[IsLatest],
		[IsRecommended],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[TotalVisit],
		[IsRemoved]
  FROM Openxml( @docHandle, '/Book', 3) WITH ( 
		
		Edition nvarchar(250),
		[CategoryID] bigint,
		[Size] nvarchar(250),
		[ISBN] int,
		[BookTitle] nvarchar(250),
		[BookWishTypeID] int,
		[AuthorID] bigint,
		[PublisherID] bigint,
		[Abstract] nvarchar(550),
		[Price] money,
		[LastVisibilityDate] datetime,
		[NumberOfUsersRate] bigint,
		[AvgRating] float,
		[PublishedDate] datetime,
		[ImageUrl] nvarchar(2000),
		[VAT]  int,
		[Version] nvarchar(250),
		[Discount] int,
		[Quantity] int,
		[IsLatest] bit,
		[IsRecommended] bit,
		[CreatedBy] bigint,
		[CreatedDate] datetime,
		[ModifiedBy] bigint,
		[ModifiedDate] datetime,
		[TotalVisit] bigint,
		[IsRemoved] bit
	 )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @BookID = SCOPE_IDENTITY()

   -------Insert BookOtherStoreUrl Table ----------

   INSERT INTO BookOtherStoreUrl(
       [BookID]
      ,[BookAvailableStoreID]
	  ,[BookAvailableUrl]
      ,[CreatedBy]
      ,[CreatedDate]
	  ,[ModifiedBy]
	  ,[ModifiedDate]
	  ,[IsRemoved]
	  )
   SELECT @BookID as BookID
      ,BookAvailableStoreID
	  ,BookAvailableUrl
      ,CreatedBy
      ,CreatedDate
	  ,ModifiedBy
	  ,ModifiedDate
	  ,IsRemoved
   FROM OpenXml( @docHandle, '/Book/BookOtherStoreUrlColl/BookOtherStoreUrl', 3)   WITH 
   (
		BookID bigint
      ,BookAvailableStoreID int
      ,BookAvailableUrl nvarchar(max)
      ,CreatedBy bigint
      ,CreatedDate datetime
	  ,ModifiedBy bigint
	  ,ModifiedDate datetime
	  ,IsRemoved bit
	) 


	-------Insert  BookMediaReviews Table ---------

   INSERT INTO BookMediaReviews(
       [BookID]
      ,[MediaName]
	  ,[MediaComments]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
	  ,[ModifiedDate]
	  ,[IsRemoved]
	  )
   SELECT @BookID as BookID
      ,[MediaName]
	  ,[MediaComments]
      ,[CreatedBy]
      ,[CreatedDate]
	  ,[ModifiedBy]
	  ,[ModifiedDate]
	  ,[IsRemoved]
   FROM OpenXml( @docHandle, '/Book/BookMediaReviewColl/BookMediaReview', 3)   WITH 
   (
		[BookID] bigint
      ,[MediaName] nvarchar(200)
	  ,[MediaComments] nvarchar(max)
      ,[CreatedBy] bigint
      ,[CreatedDate] datetime
	  ,[ModifiedBy] bigint
	  ,[ModifiedDate] datetime
	  ,[IsRemoved] bit
	)
	
	--------Insert BookOffer Table ------------

	 INSERT INTO BookOffer(
       [BookID]
      ,[OfferDescription]
	  ,[HasSpecialOffer]
	  ,[SpecialOfferDescription]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
	  ,[ModifiedDate]
	  ,[IsRemoved]
	  )
   SELECT @BookID as BookID
      ,[OfferDescription]
	  ,[HasSpecialOffer]
	  ,[SpecialOfferDescription]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
	  ,[ModifiedDate]
	  ,[IsRemoved]
   FROM OpenXml( @docHandle, '/Book/BookOfferColl/BookOffer', 3)   WITH 
   (
		[BookID] bigint
      ,[OfferDescription] nvarchar(max)
	  ,[HasSpecialOffer] bit
	  ,[SpecialOfferDescription] nvarchar(max)
      ,[CreatedBy] bigint
      ,[CreatedDate] datetime
	  ,[ModifiedBy] bigint
	  ,[ModifiedDate] datetime
	  ,[IsRemoved] bit
	)
   
   IF @@ERROR<>0 
     BEGIN 
       ROLLBACK TRANSACTION RETURN -101 
     END	 
     
      IF @@ERROR<>0 
     BEGIN 
       ROLLBACK TRANSACTION RETURN -103 
     END
COMMIT TRANSACTION------------------------------

EXEC sp_xml_removedocument @docHandle SELECT @BookID AS [Book]




GO
/****** Object:  StoredProcedure [dbo].[SearchForPoliceStationbyCountryDivisionDistrict]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<a_islam,,Asiful Islam>
-- Create date: <24.02.2015,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchForPoliceStationbyCountryDivisionDistrict] 
	-- Add the parameters for the stored procedure here
	(
	
	@policeStationName nvarchar(250),
	@districtID bigint,
	@divOrStateID bigint,
	@countryID bigint
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select IID,Name from PoliceStation where PoliceStation.IsRemoved=0 and PoliceStation.CountryID=@countryID and PoliceStation.DistrictID=@districtID and PoliceStation.DivisionOrStateID=@divOrStateID;
	
END


GO
/****** Object:  StoredProcedure [dbo].[SP_CategoryTree_GetCategoryParentID]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CategoryTree_GetCategoryParentID]
(				
	@parID bigint	
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	 SELECT 
	 CAT.ParentID

	 FROM Category CAT		

	 WHERE CAT.IsRemoved='false' AND CAT.IID= @parID		

	 END	 

END


GO
/****** Object:  StoredProcedure [dbo].[SP_CategoryTree_GetSearchedCategory]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CategoryTree_GetSearchedCategory]
(				
	@catName nvarchar(50)	
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	 SELECT * 

	 FROM Category CAT
		

	 WHERE CAT.IsRemoved='false'
	 AND (@catName IS NULL OR CAT.Name LIKE @catName + '%')		

	 END	 

END


GO
/****** Object:  StoredProcedure [dbo].[SP_CategoryTree_GetSearchedCategoryOrAll]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
	exec SP_CategoryTree_GetSearchedCategoryOrAll null,null
*/


CREATE PROCEDURE [dbo].[SP_CategoryTree_GetSearchedCategoryOrAll]
(	
    @catName nvarchar(50),
    @parId bigint			
) 	
AS

BEGIN
SET NOCOUNT ON;

IF (@parId IS NULL AND @catName IS NULL)--for get all category
 BEGIN 
 
-- WITH CTE AS
--(
--    SELECT C_PARENT.IID, C_PARENT.ParentID, C_PARENT.Name,C_PARENT.Description
--    FROM Category AS C_PARENT
--    WHERE (C_PARENT.ParentID IS NULL  AND C_PARENT.ParentID IS NULL) OR (C_PARENT.ParentID IS NULL AND C_PARENT.ParentID IS NOT NULL)

--    UNION ALL

--    SELECT C_CHILD.IID, C_CHILD.ParentID, C_CHILD.Name ,C_CHILD.Description
--    FROM Category AS C_CHILD
--    INNER JOIN CTE AS TEMP ON C_CHILD.ParentID = TEMP.IID
--)
--SELECT IID ,ParentID
--,Name,Description
--FROM CTE AS CTE_CATEGORY


  SELECT *
	 FROM Category CAT 
	 WHERE CAT.IsRemoved='false'AND CAT.ParentID IS NULL		
 END
ELSE IF (@parId IS NULL)	
BEGIN  

-- WITH CTE AS
--(
--    SELECT C_PARENT.IID, C_PARENT.ParentID, C_PARENT.Name,C_PARENT.Description
--    FROM Category AS C_PARENT
--    WHERE (C_PARENT.Name LIKE @catName + '%' AND C_PARENT.ParentID IS NULL) OR (C_PARENT.Name LIKE @catName + '%' AND C_PARENT.ParentID IS NOT NULL)

--    UNION ALL

--    SELECT C_CHILD.IID, C_CHILD.ParentID, C_CHILD.Name ,C_CHILD.Description
--    FROM Category AS C_CHILD
--    INNER JOIN CTE AS TEMP ON C_CHILD.ParentID = TEMP.IID
--)
--SELECT IID ,ParentID
--,Name,Description
--FROM CTE AS CTE_CATEGORY
 SELECT *
	 FROM Category CAT 
	 WHERE CAT.IsRemoved='false'
	 AND (@catName IS NULL OR CAT.Name LIKE @catName + '%')	
	
 END
 
ELSE 
BEGIN  	
 SELECT *
	 FROM Category CAT 
	WHERE CAT.IsRemoved='false' AND CAT.ParentID=@parId	 
END	 	 
END


GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteAllBookChildByBookID]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Asiful Islam>
-- Create date: <3/11/2015,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteAllBookChildByBookID] 
	-- Add the parameters for the stored procedure here
	(
	@BookID bigint
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update  BookMediaReviews set IsRemoved=1  where BookID=@BookID;
	Update BookOffer set IsRemoved=1 where BookID=@BookID;
	Update BookOtherStoreUrl set IsRemoved=1 where BookID=@BookID;
END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllAuthorQuote]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   OH_OT_GetAllOtherContent
	Author : Asiful Islam
	Script Date: 06/14/2015
=====================================================================================*/


create PROCEDURE [dbo].[SP_GetAllAuthorQuote]
As
--exec OH_OT_GetAllOtherContent

BEGIN TRY 


	SELECT BA.IID,BA.FavouriteQuote,BA.AuthorName
	
	FROM BookAuthor BA
	
	
	WHERE BA.IsRemoved='false'
	--AND MT.IsSpotlight=1 
	ORDER BY NEWID(),BA.CreatedDate desc

END TRY


BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllbookInfoForListView]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllbookInfoForListView 

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllbookInfoForListView]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select book.IID, 

	    CategoryInfo.CategoryName as CategoryName,
		CategoryInfo.ParentCategoryID as ParentCategoryID,
	    Author.AuthorName as AuthorName,
		Publisher.PublisherName as PublisherName,
	 	book.ISBN as ISBN,
		book.BookTitle as BookTitle,
        book.Abstract as Abstract,                                
		book.Edition  as Edition,
		book.Size  as Size,
		book.Price  as Price,
		book.LastVisibilityDate as LastVisibilityDate,
		book.PublishedDate as PublishedDate,
		book.ImageUrl as ImageUrl,
		book.VAT as VAT,
        book.Discount as Discount,
		book.IsLatest as IsLatest,
		book.IsRecommended as IsRecommended,
        book.IsRemoved as IsRemoved,
		book.Quantity as Quantity

	from Book book
	
	inner join BooKCategory CategoryInfo on book.CategoryID=CategoryInfo.IID
	inner join BookAuthor Author on book.AuthorID= Author.IID
	inner join BookPublisher Publisher on book.PublisherID= Publisher.IID

	where
	book.IsRemoved='false'
	
    
	END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllBooknewsWithPaging]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Asif>
-- Create date: <15-june-2015>
-- Description:	< >
-- =============================================


create PROCEDURE [dbo].[SP_GetAllBooknewsWithPaging]
(
--@HelpSupportTypeID int,
@StartIndex int=0,
@MaximumRows int=0
)
-- Exec SP_GetAllBooknewsWithPaging 0,5
AS
BEGIN TRY 

  BEGIN	
	DECLARE @EndRow bigint
	SET @EndRow= @StartIndex+@MaximumRows;


SELECT  F.IID,F.RowNumber,F.HeadLine,F.[Description],F.[Image],f.Audio,f.PublishDate,f.VideoLink 
		FROM
		(
		 SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate  DESC) AS RowNumber, 
		 ISNULL (HeadLine,'')HeadLine, 
		 ISNULL ([NewsDescription],'')[Description], 
		 ISNULL ([ImageUrl],'')[Image],
		 ISNULL ([VideoLink],'')[VideoLink],
		 ISNULL ([Audio],'')[Audio],
		 ISNULL ([PublishDate],'')[PublishDate],
		 IID	  
		 FROM BookNews Where IsRemoved=0
		) F
	WHERE  (@StartIndex is null or F.RowNumber >=@StartIndex+1) 
	AND(@EndRow is null or F.RowNumber <= @EndRow) 
	
	ORDER BY F.IID desc
 END

/*************END For Collecting Data*****************/

END TRY


BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCompetition]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   SP_GetAllCompetition 0, 2


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetAllCompetition]
(
	@startRowNumber int,
	@maxRowNumber int
)
As

BEGIN TRY 
Set @maxRowNumber = @startRowNumber+ @maxRowNumber

BEGIN
		Select 
		F.ROWNUMBER,
		F.IID,
		F.CompetitionTypeID,
		F.CompetitionStartDate,
		F.CompetitionEndDate,
		F.Title,
		F.Description,
		F.UploadFile,
		F.ImageUrl,
		F.LocationID,
		F.SeasonID,
		F.IsRemoved
		FROM 
		(SELECT *,ROW_NUMBER() Over(ORDER BY c.IID ) ROWNUMBER
		FROM Competition AS c
		WHERE c.IsRemoved=0
		) F
		WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
END	

END TRY




BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH

--exec SP_GetAllMorgageWithInterestRate 0,10,-1,-1,-1,2
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCompetitionForListView]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Asiful Islam>
-- Create date: <2/24/2015 >

CREATE PROC [dbo].[SP_GetAllCompetitionForListView]
As

BEGIN TRY 

-- Retrieve column specific information 

	SELECT 
		com.IID,
		com.CompetitionTypeID,
		CONVERT(nvarchar,com.CompetitionTypeID) AS CompetitionType,
		com.Title,
		com.CompetitionStartDate,
		com.CompetitionEndDate,
		com.Description,
		com.UploadFile,
		com.ImageUrl,
		loc.CurrentLocation,
		com.SeasonID,
		CONVERT(nvarchar,com.SeasonID) AS Season,
		com.IsRemoved
	FROM Competition com	
	LEFT JOIN Location loc ON loc.IID=com.LocationID
	WHERE com.IsRemoved=0


END TRY


BEGIN CATCH
	--goto ErrHandler
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH





GO
/****** Object:  StoredProcedure [dbo].[SP_GetDistrictForSearch]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetDistrictForSearch]
(				
	@districtName nvarchar(50),	
	@countryId int
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	  SELECT 
	 
	  DIST.IID as DistrictID,	  
	  COUNTRY.IID as CountryID,	 
	  DIVSTATE.IID as DivisionOrStateID,
	  DIVSTATE.Name as DivisionOrStateName,	  
	  DIST.Name as DistrictName,
	  COUNTRY.Name as CountryName
	
	

	 FROM District DIST	 
	 INNER JOIN DivisionOrState DIVSTATE ON DIVSTATE.IID=DIST.DivisionOrStateID
	 INNER JOIN Country COUNTRY ON COUNTRY.IID=DIST.CountryID	 
	

	 WHERE DIST.IsRemoved='false' AND Country.IsRemoved='false' AND DIVSTATE.IsRemoved='false'
	 AND (@countryId IS NULL OR COUNTRY.IID = @countryId)	
	 AND (@districtName IS NULL OR DIST.Name LIKE @districtName + '%')		

	 END	 

END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetLocationForGoogleMap]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

	EXEC SP_GetLocationForGoogleMap 3

*/

CREATE PROCEDURE [dbo].[SP_GetLocationForGoogleMap]
(		
	@locationID BIGINT	
) 
AS

  BEGIN
	 SET NOCOUNT ON;

	 BEGIN
	
	  SELECT TOP 1
	 
	  ISNULL(LOC.CurrentLocation,'')  AS CurrentLocation,	 
	  ISNULL(PS.Name,'')as PoliceStationName,
	  ISNULL(DIST.Name,'') as DistrictName,
	  ISNULL(DIVSTATE.Name,'') as DivisionOrStateName,
	  ISNULL(COUNTRY.Name,'') as CountryName
		

	 FROM PoliceStation PS	 
	 INNER JOIN District DIST ON PS.DistrictID=DIST.IID
	 INNER JOIN DivisionOrState DIVSTATE ON PS.DivisionOrStateID=DIVSTATE.IID
	 INNER JOIN Country COUNTRY ON PS.CountryID=COUNTRY.IID
	 inner JOIN Location LOC ON PS.IID=LOC.PoliceStationID
	 inner join Material material on LOC.IID=material.LocationID 

    WHERE PS.IsRemoved='false' AND DIST.IsRemoved='false' AND Country.IsRemoved='false' AND DIVSTATE.IsRemoved='false'
	 AND (@locationID IS not NULL)	and material.LocationID=@locationID	 

	 END
	
	END 
	




GO
/****** Object:  StoredProcedure [dbo].[SP_GetLocationForSearch]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetLocationForSearch]
(		
	@locationName nvarchar(50),	
	@policeStationId bigint,
	@districtId bigint,
	@countryId int
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	  SELECT 
	  PS.IID as PoliceStationID,
	  DIST.IID as DistrictID,	  
	  COUNTRY.IID as CountryID,
	  LOC.IID as LocationID,
	  DIVSTATE.IID as DivisionOrStateID,

	  DIVSTATE.Name as DivisionOrStateName,
	  PS.Name as PoliceStationName,
	  DIST.Name as DistrictName,
	  COUNTRY.Name as CountryName,
	  LOC.CurrentLocation as CurrentLocationName
	

	 FROM PoliceStation PS	 
	 INNER JOIN District DIST ON PS.DistrictID=DIST.IID
	 INNER JOIN DivisionOrState DIVSTATE ON PS.DivisionOrStateID=DIVSTATE.IID
	 INNER JOIN Country COUNTRY ON PS.CountryID=COUNTRY.IID
	 LEFT JOIN Location LOC ON PS.IID=LOC.PoliceStationID
	 	 

	 WHERE PS.IsRemoved='false' AND DIST.IsRemoved='false' AND Country.IsRemoved='false' AND DIVSTATE.IsRemoved='false'
	 AND (@countryId IS NULL OR COUNTRY.IID = @countryId)	
	 AND (@districtId IS NULL OR DIST.IID=@districtId)	
	 AND (@policeStationId IS NULL OR PS.IID=@policeStationId)	
	 AND (@locationName IS NULL OR LOC.CurrentLocation LIKE @locationName + '%')		 

	 END	 

END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetPoliceStaionForSearch]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetPoliceStaionForSearch]
(			
	@policeStationName nvarchar(50),	
	@districtId bigint,
	@countryId int
) 
	
AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN

	  SELECT 
	  PS.IID as PoliceStationID,
	  DIST.IID as DistrictID,	  
	  COUNTRY.IID as CountryID,	 
	  DIVSTATE.IID as DivisionOrStateID,

	  DIVSTATE.Name as DivisionOrStateName,
	  PS.Name as PoliceStationName,
	  DIST.Name as DistrictName,
	  COUNTRY.Name as CountryName
	
	

	 FROM PoliceStation PS	 
	 INNER JOIN District DIST ON PS.DistrictID=DIST.IID
	 INNER JOIN DivisionOrState DIVSTATE ON PS.DivisionOrStateID=DIVSTATE.IID
	 INNER JOIN Country COUNTRY ON PS.CountryID=COUNTRY.IID
	
	 	 

	 WHERE PS.IsRemoved='false' AND DIST.IsRemoved='false' AND Country.IsRemoved='false' AND DIVSTATE.IsRemoved='false'
	 AND (@countryId IS NULL OR COUNTRY.IID = @countryId)	
	 AND (@districtId IS NULL OR DIST.IID=@districtId)	
	 AND (@policeStationName IS NULL OR PS.Name LIKE @policeStationName + '%')			 

	 END	 

END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetWholeWebSearch]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Asiful Islam>
-- Create date: <04/06/2015 >

CREATE PROC [dbo].[SP_GetWholeWebSearch]

(	
	@SearchKeyWord	nvarchar(50)
	
	
) 
	
As

BEGIN TRY 

-- Retrieve column specific information 

	 SELECT 
	 MAT.IID ,
	 MAT.TitleName,
	 MAT.Code,
	 MAT.Description as Matdis,
	 CAT.Description as catdis,
	 CAT.Name as CategoryName
	 --CAT.IID as catID

	 FROM Material MAT
	 
	 full JOIN Category CAT ON MAT.CategoryID= CAT.IID	 

	 WHERE 
	 
	 (MAT.TitleName COLLATE Latin1_General_CI_AS like RTRIM (@SearchKeyWord) + '%' or MAT.TitleName COLLATE Latin1_General_CI_AS like '%@SearchKeyWord' or MAT.TitleName COLLATE Latin1_General_CI_AS like '%@SearchKeyWord%' And MAT.IsExpired='false') 
	 OR (CAT.Name COLLATE Latin1_General_CI_AS like RTRIM (@SearchKeyWord) + '%' or CAT.Name COLLATE Latin1_General_CI_AS like '%@SearchKeyWord' or CAT.Name COLLATE Latin1_General_CI_AS like '%@SearchKeyWord%' and CAT.IsRemoved='false') 
	



END TRY


BEGIN CATCH
	--goto ErrHandler
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAccNamePhone]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   sp_UpdateAccNamePhone
	Author : Asiful Islam
	Script Date: 3/18/2015
=====================================================================================*/


CREATE PROCEDURE [dbo].[sp_UpdateAccNamePhone]
(	

	@userEmailId nvarchar(50),
	@Name nvarchar(50),
	@PhoneNo1 nvarchar(50)

	
) 
As

BEGIN TRY 

UPDATE AdGiver SET Name=@Name, PhoneNo1=@PhoneNo1 WHERE EmailID=@userEmailId;
	

END TRY


BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAccPassword]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   sp_UpdateAccPassword
	Author : Asiful Islam
	Script Date: 3/18/2015
=====================================================================================*/


create PROCEDURE [dbo].[sp_UpdateAccPassword]
(	

	@userEmailId nvarchar(50),
	@LoginPassword nvarchar(250)
	

	
) 
As

BEGIN TRY 

--UPDATE UserInfo SET Name=@Name, PhoneNo1=@PhoneNo1 WHERE EmailID=@userEmailId;
UPDATE
    UserInfo
SET
    UserInfo.LoginPassword = @LoginPassword
where 
	(select AdGiver.IID from AdGiver where AdGiver.EmailID=@userEmailId)=UserInfo.AdGiverID
  

END TRY


BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUserDeactivation]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   sp_UpdateUserDeactivation
	Author : Asiful Islam
	Script Date: 3/30/2015
=====================================================================================*/


CREATE PROCEDURE [dbo].[sp_UpdateUserDeactivation]
(	

	@userEmailId nvarchar(50),
	@Comments nvarchar(500),
	@LeavingCausesID int,
	@IsActiveUser bit
	

	
) 
As

BEGIN TRY 

--UPDATE UserInfo SET Name=@Name, PhoneNo1=@PhoneNo1 WHERE EmailID=@userEmailId;
UPDATE
    UserInfo
SET
    UserInfo.Comments = @Comments,
	UserInfo.LeavingCausesID = @LeavingCausesID,
	UserInfo.IsActiveUser = @IsActiveUser
where 
	(select AdGiver.IID from AdGiver where AdGiver.EmailID=@userEmailId)=UserInfo.AdGiverID
  

END TRY


BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[SpDeleteUrlList]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpDeleteUrlList]
	
(
	@DeleteUrlList int = 0
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  Delete From UrlWFList Where IID = @DeleteUrlList

END



GO
/****** Object:  StoredProcedure [dbo].[SpGetAllPoliceStation]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <2/15/2015 >

CREATE PROC [dbo].[SpGetAllPoliceStation]
As

BEGIN TRY 

-- Retrieve column specific information 

	SELECT policeSt.IID, policeSt.Code, policeSt.Name,policeSt.IsRemoved, country.Name CountryName, division.Name DivisionOrState, district.Name  District 
	from PoliceStation policeSt
	left join District district ON policeSt.DistrictID=district.IID
	join DivisionOrState division ON division.IID=district.DivisionOrStateID
	join Country country ON country.IID=division.CountryID
	--WHERE policeSt.IsRemoved=0 
	--WHERE country.IsRemoved=0 and policeSt.IsRemoved=0 and district.IsRemoved=0 and division.IsRemoved=0


END TRY


BEGIN CATCH
	--goto ErrHandler
	
	DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Use RAISERROR inside the CATCH block to return error
		-- information about the original error that caused
		-- execution to jump to the CATCH block.
		RAISERROR (@ErrorMessage, -- Message text.
				   @ErrorSeverity, -- Severity.
				   @ErrorState -- State.
				   );

		RETURN -1
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[SpGetData]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpGetData] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select * from District 
	
END



GO
/****** Object:  UserDefinedFunction [dbo].[UFN_HourMinuteSecond]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
		0 Year(s), 5 Month(s), 1 Day(s), 1 Hour(s), 59 Minute(s) ago.


		SELECT dbo.UFN_HourMinuteSecond ('2015-03-09 12:34:12.000','2015-03-09 12:38:12.000')


*/

CREATE FUNCTION [dbo].[UFN_HourMinuteSecond]
(
	@StartDateTime	DATETIME,
	@EndDateTime	DATETIME
) 

RETURNS NVARCHAR(200) 

As
BEGIN

		DECLARE @Seconds	INT,
				@Minute		INT,
				@Hour		INT,
				@Days		INT,
				@Month		INT,
				@Year		INT,
				@Elapsed	NVARCHAR(200)=''

		SELECT @Seconds = ABS(DateDiff(SECOND ,@StartDateTime,@EndDateTime))

		IF @Seconds >= 60 
			BEGIN
				SELECT @Minute = @Seconds/60
				SELECT @Seconds = @Seconds%60

				IF @Minute >= 60
				BEGIN
					SELECT @hour = @Minute/60
					SELECT @Minute = @Minute%60
				END

				IF @hour >= 24
				BEGIN
					SELECT @Days = @hour/24
					SELECT @hour = @hour%24
				END

				IF @Days >= 30
				BEGIN
					SELECT @Month = @Days/30
					SELECT @Days = @Days%30
				END

				IF @Month >= 12
				BEGIN
					SELECT @Year = @Month/12
					SELECT @Month = @Month%12
				END

				ELSE
				GOTO FINAL 
			END

		FINAL:
		
		SELECT @Seconds =ISNULL(@Seconds,0)		
		SELECT @Minute =ISNULL(@Minute,0); 
		SELECT @Hour =ISNULL(@Hour,0); 
		SELECT @Days=ISNULL(@Days,0);
		SELECT @Month=ISNULL(@Month,0);
		SELECT @Year=ISNULL(@Year,0);

		--SELECT @Elapsed =CAST(@Year AS NVARCHAR)+' Year(s), '+CAST(@Month AS NVARCHAR)+' Month(s), '
		--+CAST(@Days AS NVARCHAR)+' Day(s), '+ Cast(@Hour AS NVARCHAR) + ' Hour(s), ' + Cast(@Minute AS NVARCHAR)
		--+ ' Minute(s), ' +     Cast(@Seconds AS NVARCHAR)+' Second(s) ago.'

		IF(@Year>0)
		SET @Elapsed=@Elapsed+CAST(@Year AS NVARCHAR)+' Year(s), ';

		IF(@Month>0)
		SET @Elapsed=@Elapsed+CAST(@Month AS NVARCHAR)+' Month(s), ';

		IF(@Days>0)
		SET @Elapsed=@Elapsed+CAST(@Days AS NVARCHAR)+' Day(s), ';

		IF(@Hour>0)
		SET @Elapsed=@Elapsed+Cast(@Hour AS NVARCHAR) + ' Hour(s), ';

		IF(@Minute>0)
		SET @Elapsed=@Elapsed+Cast(@Minute AS NVARCHAR)+ ' Minute(s) ';

		--IF(@Seconds>0)
		--SET @Elapsed=@Elapsed+Cast(@Seconds AS NVARCHAR)+' Second(s)';

		SET @Elapsed=@Elapsed+' ago.';

		--RETURN (@Elapsed + '==' + @Month)

		RETURN (@Elapsed)
END


GO
/****** Object:  Table [dbo].[AdGiver]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdGiver](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ClientTypeID] [int] NOT NULL,
	[NationalID] [nvarchar](50) NULL,
	[CompanyOrOrganizationName] [nvarchar](250) NULL,
	[ComOrOrgAddress] [nvarchar](500) NULL,
	[ComOrOrgPhone] [nvarchar](50) NULL,
	[EmailID] [nvarchar](250) NOT NULL,
	[PhoneNo1] [nvarchar](50) NOT NULL,
	[PhoneNo2] [nvarchar](50) NULL,
	[LocationID] [bigint] NULL,
	[TotalPostNo] [int] NULL,
	[IsVerified] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_AdGivger] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdGiverTracing]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdGiverTracing](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[AdGiverID] [bigint] NOT NULL,
	[BookID] [bigint] NULL,
	[IPAddress] [nvarchar](50) NOT NULL,
	[MACAddress] [nvarchar](50) NULL,
	[BrowserNameID] [int] NULL,
	[BrowsingTimeDuration] [nvarchar](50) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AdGiverTracing] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Edition] [nvarchar](250) NULL,
	[CategoryID] [bigint] NOT NULL,
	[Size] [nvarchar](250) NULL,
	[ISBN] [int] NOT NULL,
	[TotalVisit] [bigint] NOT NULL,
	[BookTitle] [nvarchar](250) NOT NULL,
	[BookWishTypeID] [int] NOT NULL,
	[AuthorID] [bigint] NOT NULL,
	[PublisherID] [bigint] NOT NULL,
	[Abstract] [nvarchar](1000) NOT NULL,
	[Price] [money] NOT NULL,
	[LastVisibilityDate] [datetime] NOT NULL,
	[NumberOfUsersRate] [bigint] NULL,
	[AvgRating] [float] NULL,
	[PublishedDate] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](2000) NULL,
	[VAT] [int] NULL,
	[Version] [nvarchar](250) NULL,
	[Discount] [int] NULL,
	[Quantity] [int] NULL,
	[IsLatest] [bit] NOT NULL,
	[IsRecommended] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Picture] [nvarchar](2500) NULL,
	[AuthorName] [nvarchar](250) NOT NULL,
	[FavouriteQuote] [nvarchar](2500) NULL,
	[CountryID] [int] NULL,
	[WebsiteLink] [nvarchar](250) NULL,
	[AboutAuthor] [nvarchar](2500) NOT NULL,
	[IsFeatured] [bit] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BooKCategory]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooKCategory](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](2500) NULL,
	[CategoryDescription] [nvarchar](2500) NOT NULL,
	[CategoryName] [nvarchar](250) NOT NULL,
	[DisplayOrder] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[ParentCategoryID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BooKCategory] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookMediaReviews]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookMediaReviews](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [bigint] NOT NULL,
	[MediaName] [nvarchar](200) NULL,
	[MediaComments] [nvarchar](max) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookMediaReviews] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookNews]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookNews](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[VideoLink] [nvarchar](max) NULL,
	[Audio] [nvarchar](max) NULL,
	[HeadLine] [nvarchar](500) NOT NULL,
	[NewsDescription] [ntext] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookNews] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookNewsLetter]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookNewsLetter](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](200) NOT NULL,
	[IsSubscribe] [bit] NOT NULL,
	[SubscribeDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_OiiONewsLetter] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookOffer]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOffer](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [bigint] NOT NULL,
	[OfferDescription] [nvarchar](max) NOT NULL,
	[HasSpecialOffer] [bit] NOT NULL,
	[SpecialOfferDescription] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookOffer] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookOrder]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrder](
	[IID] [bigint] NOT NULL,
	[UserID] [bigint] NULL,
	[Quantity] [int] NULL,
	[Payment] [nvarchar](250) NULL,
	[ShippingDate] [nchar](10) NULL,
	[ShippingAddress] [nvarchar](550) NULL,
	[TotalPrice] [money] NULL,
	[ShippingCost] [money] NULL,
	[LocationID] [nvarchar](250) NULL,
	[UserComment] [nvarchar](2550) NULL,
	[AdditionalMobile] [nchar](10) NULL,
	[PaymentStatusID] [int] NULL,
	[ShippingStatusID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookOrder] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookOrderItem]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOrderItem](
	[IID] [bigint] NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[BookID] [bigint] NOT NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [money] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookOrderItem] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookOtherStoreUrl]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookOtherStoreUrl](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [bigint] NOT NULL,
	[BookAvailableStoreID] [int] NULL,
	[BookAvailableUrl] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BooksFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookPublisher]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookPublisher](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](250) NOT NULL,
	[PublisherLogoUrl] [nvarchar](2500) NOT NULL,
	[AwardAchieved] [nvarchar](2500) NULL,
	[WebsiteLink] [nvarchar](2500) NULL,
	[AboutPublisher] [nvarchar](2500) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BookPublisher] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMSContent]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMSContent](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CMSTypeID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[CMSDescription] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CMSContent] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Competition]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompetitionTypeID] [bigint] NULL,
	[Title] [nvarchar](500) NOT NULL,
	[CompetitionStartDate] [datetime] NOT NULL,
	[CompetitionEndDate] [datetime] NOT NULL,
	[Description] [nvarchar](2500) NULL,
	[UploadFile] [nvarchar](2500) NOT NULL,
	[ImageUrl] [nvarchar](2500) NULL,
	[LocationID] [bigint] NOT NULL,
	[SeasonID] [nvarchar](250) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Competition] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompetitionRegistration]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetitionRegistration](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[UploadFile] [nvarchar](500) NULL,
	[ContestantId] [bigint] NOT NULL,
	[CompetitionID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CompetitionRegistration] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contestant]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contestant](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[IsEmail] [bit] NOT NULL,
	[ProfessionID] [int] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[LoginName] [nvarchar](250) NOT NULL,
	[LoginPassword] [nvarchar](250) NOT NULL,
	[Salt] [nvarchar](250) NULL,
	[IsActiveUser] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Contestant] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ISDCode] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[DivisionOrStateID] [bigint] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DivisionOrState]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionOrState](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_DivisionOrState] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[DistrictID] [bigint] NOT NULL,
	[SubDistrictID] [bigint] NULL,
	[PoliceStationID] [bigint] NOT NULL,
	[PostOfficeID] [bigint] NULL,
	[CurrentLocation] [nvarchar](250) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemove] [bit] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MyFavourites]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyFavourites](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaterialID] [bigint] NOT NULL,
	[UserLoginID] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ReturnURL] [nvarchar](300) NULL,
 CONSTRAINT [PK_MyFavourites] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OiiOBook]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OiiOBook](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Logo] [nvarchar](200) NOT NULL,
	[LoginLogo] [nvarchar](200) NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OiiOBook] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OiiOOthers]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OiiOOthers](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ShortDescription] [nvarchar](300) NOT NULL,
	[DetailDescription] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_OiiOOthers] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoliceStation]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoliceStation](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[DivisionOrStateID] [bigint] NOT NULL,
	[DistrictID] [bigint] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_PoliceStation] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostOffice]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostOffice](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](250) NOT NULL,
	[PoliceStationID] [bigint] NULL,
	[SubDistrictID] [bigint] NULL,
	[DistrictID] [bigint] NOT NULL,
	[DivisionOrStateID] [bigint] NOT NULL,
	[CountryID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_PostOffice] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profession]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profession](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[Name] [nvarchar](500) NULL,
	[Note] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Profession] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UrlWFList]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrlWFList](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](250) NULL,
	[ModuleSerialNo] [int] NULL,
	[UrlWFName] [nvarchar](900) NULL,
	[UrlWFSerialNo] [int] NULL,
	[UrlWFDisplayName] [nvarchar](250) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_UrlWFList] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[TypeID] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserGroupID] [int] NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[LoginName] [nvarchar](250) NOT NULL,
	[LoginPassword] [nvarchar](250) NOT NULL,
	[Salt] [nvarchar](250) NULL,
	[IsActiveUser] [bit] NULL,
	[IsEmail] [bit] NOT NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_UserInfo_1] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRatings]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRatings](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [bigint] NULL,
	[Ratings] [int] NULL,
	[UserID] [bigint] NULL,
 CONSTRAINT [PK_UserRatings] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserWFPermission]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserWFPermission](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserGroupID] [int] NULL,
	[UrlWFListID] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_UserWFPermission] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitorCounter]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorCounter](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[TotalVisitor] [bigint] NOT NULL,
	[VisitDate] [datetime] NULL,
 CONSTRAINT [PK_VisitorCounter] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitorInfo]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nvarchar](250) NOT NULL,
	[IPType] [nchar](10) NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_VisitorInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitorInfoDetails]    Script Date: 6/23/2015 12:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorInfoDetails](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[VisitorInfoID] [bigint] NULL,
	[AccessDateTime] [datetime] NOT NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_VisitorInfoDetails] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'First', 1, N'300 page', 2343454, 1, N'comics & thriller', 10, 1, 2, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 234.0000, CAST(0x0000A4C4000E6D03 AS DateTime), 25, 2.65, CAST(0x0000A4B8000E6D03 AS DateTime), N'~/Images/Interfaces/10.png', 2, N'2', 10, 5, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A48200CEBE3E AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'1st', 1, N'500 page', 2343454, 0, N'Romance1', 3, 1, 2, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 234.0000, CAST(0x0000A4C401257060 AS DateTime), NULL, NULL, CAST(0x0000A4B800000000 AS DateTime), N'~/images/interfaces/11.png', 10, N'v2', 9, 5, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'First', 1, N'300 page', 2343454, 0, N'comics1', 2, 1, 2, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 234.0000, CAST(0x0000A4C401087EAC AS DateTime), NULL, NULL, CAST(0x0000A4B800000000 AS DateTime), N'~/images/interfaces/11.png', 10, N'v1', 10, 5, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A4B901098E55 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'First', 2, NULL, 2343454, 1, N'Art & thriller', 7, 1, 2, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 234.0000, CAST(0x0000A4C4000E6D03 AS DateTime), 120, 4.6, CAST(0x0000A4B8000E6D03 AS DateTime), N'~/images/interfaces/10.png', NULL, NULL, NULL, NULL, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A48200CEBE3E AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'First', 1, NULL, 2343454, 1, N'Romance2', 1, 1, 2, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 234.0000, CAST(0x0000A4C4000E6D03 AS DateTime), 22, 3.9, CAST(0x0000A499000E6D03 AS DateTime), N'~/images/interfaces/11.png', NULL, NULL, NULL, NULL, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A48200CEBE3E AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, N'First', 2, NULL, 2343454, 1, N'comics2', 2, 1, 2, N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim. ', 234.0000, CAST(0x0000A4C4000E6D03 AS DateTime), 10, 2, CAST(0x0000A499000E6D03 AS DateTime), N'~/images/interfaces/10.png', NULL, NULL, NULL, NULL, 1, 1, 1, CAST(0x0000A47B000E6D03 AS DateTime), 1, CAST(0x0000A48200CEBE3E AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, N'second', 5, NULL, 763465, 1, N'Flying with Confidence: The proven programme to fix your flying fears', 2, 2, 3, N'If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.If so, this book could change your life. Written by top flying experts from British Airways’ Flying with Confidence course, this reassuring guide explains everything you need to know about air travel alongside techniques for feeling confident and in control from take off to landing. In easy-to-follow sections, you''ll learn how to recognize cabin noises, manage turbulence and fly in bad weather conditions. As your knowledge grows, so will your confidence, with the fear of the unknown removed.', 789.0000, CAST(0x0000A499011A4869 AS DateTime), 5, 1.7, CAST(0x0000A499000E6D03 AS DateTime), N'~/images/interfaces/11.png', NULL, NULL, 0, 7, 1, 1, 1, CAST(0x0000A48D011A4E7D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, N'3rd', 1, N'', 12345, 1, N'Programming C', 3, 1, 2, N'', 520.0000, CAST(0x0000A4B400497898 AS DateTime), 0, 1.2, CAST(0x0000A4AC00C5C100 AS DateTime), N'~/images/interfaces/11.png', 0, N'', 10, 2, 1, 1, 1, CAST(0x0000A4AA004A5998 AS DateTime), 0, NULL, 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, N'3rd', 1, N'', 12345, 1, N'Programming C++', 4, 1, 2, N'', 520.0000, CAST(0x0000A4B4004B2DB4 AS DateTime), 0, 1.3, CAST(0x0000A4AD00C5C100 AS DateTime), N'~/Image/BookImage/Book_12345.jpg', 0, N'', 10, 2, 1, 0, 1, CAST(0x0000A4AA004C16E8 AS DateTime), 0, NULL, 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10019, N'3rd', 1, N'', 12345, 500, N'Programming C++', 2, 3, 4, N'ABC', 0.0000, CAST(0x0000A4C300AACDC0 AS DateTime), 0, 0, CAST(0x0000A4AB00000000 AS DateTime), N'', 0, N'', 10, 0, 1, 0, 1, CAST(0x0000A4B90049050E AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10020, N'3rd', 1, N'', 12345, 500, N'Programming C', 5, 3, 4, N'ABC', 150.0000, CAST(0x0000A4C300AC44FE AS DateTime), 0, 0, CAST(0x0000A4AA00000000 AS DateTime), N'', 0, N'', 10, 2, 1, 1, 1, CAST(0x0000A4B9004A74E2 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10021, N'3rd', 1, NULL, 12345, 500, N'Programming C', 6, 3, 4, N'ABC', 150.0000, CAST(0x0000A4C300AC44FE AS DateTime), NULL, NULL, CAST(0x0000A4AA00000000 AS DateTime), NULL, NULL, NULL, 10, 2, 1, 1, 1, CAST(0x0000A4B900AC4518 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10022, N'3rd', 5, N'', 54321, 500, N'Algorithm', 3, 1, 4, N'CBA', 150.0000, CAST(0x0000A4C300AD7CE7 AS DateTime), 0, 0, CAST(0x0000A4AB00000000 AS DateTime), N'', 0, N'', 10, 2, 1, 1, 1, CAST(0x0000A4B9004BACCC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10023, N'3rd', 5, NULL, 54321, 500, N'Algorithm', 4, 1, 4, N'CBA', 150.0000, CAST(0x0000A4C300AD7CE7 AS DateTime), NULL, NULL, CAST(0x0000A4AB00000000 AS DateTime), NULL, NULL, NULL, 10, 2, 1, 1, 1, CAST(0x0000A4B900AD7CFE AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10025, N'4th', 1, N'', 123456789, 0, N'Data Structure', 2, 2, 6, N'ABC', 100.0000, CAST(0x0000A4C300C7417F AS DateTime), 0, 0, CAST(0x0000A4AA00000000 AS DateTime), N'', 0, N'', 10, 2, 1, 1, 1, CAST(0x0000A4B900657167 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[Book] ([IID], [Edition], [CategoryID], [Size], [ISBN], [TotalVisit], [BookTitle], [BookWishTypeID], [AuthorID], [PublisherID], [Abstract], [Price], [LastVisibilityDate], [NumberOfUsersRate], [AvgRating], [PublishedDate], [ImageUrl], [VAT], [Version], [Discount], [Quantity], [IsLatest], [IsRecommended], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10026, N'3rd', 2, N'350 page', 13254, 0, N'Math-2', 2, 3, 4, N'ABC', 150.0000, CAST(0x0000A4CD0125ED48 AS DateTime), NULL, NULL, CAST(0x0000A4AA00000000 AS DateTime), N'', 10, N'version1', 10, 1, 1, 1, 1, CAST(0x0000A4B900B03886 AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

INSERT [dbo].[BookAuthor] ([IID], [Picture], [AuthorName], [FavouriteQuote], [CountryID], [WebsiteLink], [AboutAuthor], [IsFeatured], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'~/images/interfaces/61.jpg', N'Janey Crasey', N'"The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) ."The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams)  The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) . The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) ', 1, NULL, N'With the help of students, this author created an original story for Scholastic and explained how the writing process unfolds.With the help of students, this author created an original story for Scholastic and explained how the writing process unfolds.', 1, 1, CAST(0x0000A47000000000 AS DateTime), 1, CAST(0x0000A4B700D52087 AS DateTime), 1)
INSERT [dbo].[BookAuthor] ([IID], [Picture], [AuthorName], [FavouriteQuote], [CountryID], [WebsiteLink], [AboutAuthor], [IsFeatured], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'~/Image/AuthorImage/Steve Allright.jpg', N'Steve Allright', N'"The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) ."The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams)  The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) . The very least you can do in your life is figure out what you hope for. And the most you can do is live inside that hope. Not admire it from a distance, but live right in it, under its roof." — Barbara Kingsolver (Animal Dreams) ', 1, NULL, N'Patricia Furness-Smith is a psychologist and psychotherapist with over 20 years of experience. She has lectured in psychology, psychotherapy and psychopathology as well as teacher training for a number of institutions. Patricia has been a member of the Flying with Confidence team for over 10 years and worked as an air stewardess on her gap year. She lives in the Chilterns.  Captain Steve Allright is a British Airways training captain on the Boeing 747. A professional pilot since 1990, he has clocked up over 11,000 flying hours. He has been part of the Flying with Confidence team for 20 years and is now a director of the company. He lives in Buckinghamshire.', 1, 1, CAST(0x0000A48D01133CD3 AS DateTime), 1, CAST(0x0000A4B700D3C0B3 AS DateTime), 0)
INSERT [dbo].[BookAuthor] ([IID], [Picture], [AuthorName], [FavouriteQuote], [CountryID], [WebsiteLink], [AboutAuthor], [IsFeatured], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'~/Image/AuthorImage/Humayun Ahmed.jpg', N'Humayun Ahmed', N'যখন মানুষের খুব প্রিয় কেউ তাকে অপছন্দ, অবহেলা কিংবা ঘৃণা করে তখন প্রথম প্রথম মানুষ খুব কষ্ট পায় এবং চায় যে সব ঠিক হয়ে যাক । কিছুদিন পর সে সেই প্রিয় ব্যক্তিকে ছাড়া থাকতে শিখে যায়। আর অনেকদিন পরে সে আগের চেয়েও অনেকবেশী খুশি থাকে যখন সে বুঝতে পারে যে কারো ভালবাসায় জীবনে অনেক কিছুই আসে যায় কিন্তু কারো অবহেলায় সত্যিই কিছু আসে যায় না', 1, NULL, N'Humayun Ahmed (pronounced: [ɦumae̯un aɦmed̪] 13 November 1948 – 19 July 2012) was a Bangladeshi author, dramatist, screenwriter, playwright and filmmaker.Dawn referred to him as the cultural legend of Bangladesh.Ahmed was famous of his novel Nondito Noroke (In Blissful Hell). He wrote many fiction and non-fiction books.Critics appriciated his works.Ahmed''s books have been the best sellers during the 1990s and 2000s.', 1, 1, CAST(0x0000A4B3010691EB AS DateTime), 1, CAST(0x0000A4B30108394F AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
SET IDENTITY_INSERT [dbo].[BooKCategory] ON 

INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'~/Images/Interfaces/15.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'Crime & Thriller', 123, NULL, 1, 0, CAST(0x0000A47B000A9458 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'~/Images/Interfaces/14.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'Romance & Sagas', 123, NULL, 2, 0, CAST(0x0000A48200DE5001 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'~/Images/Interfaces/15.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'Historical Fiction', 123, NULL, 1, 0, CAST(0x0000A47B000A9458 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'~/Images/Interfaces/15.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'Art & Music', 123, NULL, 1, 0, CAST(0x0000A48200DE5001 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'~/Images/Interfaces/14.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'Business', 123, NULL, 2, 0, CAST(0x0000A48200DE5001 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BooKCategory] ([IID], [ImageUrl], [CategoryDescription], [CategoryName], [DisplayOrder], [LastUpdatedDate], [ParentCategoryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'~/Images/Interfaces/14.png', N'Created in 1979 as a rock music publisher, linked to Virgin Records. Primarily a non-fiction imprint, Virgin Books publishes across a broad range of subjects from music, humour and biography to business, lifestyle, TV tie-ins and reference. Our authors include Sir Richard Branson, Jay-Z, David Essex, Fatima Whitbread, Spike Milligan and Stephen Sondheim.', N'History', 123, NULL, 2, 0, CAST(0x0000A48200DE5001 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BooKCategory] OFF
SET IDENTITY_INSERT [dbo].[BookMediaReviews] ON 

INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'The Gurdian', N'This is the best book', 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, N'Economist', N'nice book', 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 10019, N'media', N'Media', 0, CAST(0x0000A4B900AAA150 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 10019, N'Media Book', N'Media Book', 0, CAST(0x0000A4B900AAAE68 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 10020, N'Media Book', N'Media Book Comment', 0, CAST(0x0000A4B900AC2CBD AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 10022, N'Media Book', N'Media Book Comment', 0, CAST(0x0000A4B900AC2CBD AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 10022, N'Media Book New', N'Media Book New Comment', 1, CAST(0x0000A4B900AD5EBA AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 10025, N'Media Book New', N'Book media comment', 0, CAST(0x0000A4B900C70D6D AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 2, N'media', N'Media', 1, CAST(0x0000A4B900FDD827 AS DateTime), 1, CAST(0x0000A4B900FEE7A5 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 2, N'Media Book', N'Media Book', 1, CAST(0x0000A4B900FDD835 AS DateTime), 1, CAST(0x0000A4B900FEE7A5 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 2, N'Media Book New', N'Media Book New', 1, CAST(0x0000A4B900FDD83F AS DateTime), 1, CAST(0x0000A4B900FEE7A5 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (15, 2, N'Media Book', N'Media Book', 1, CAST(0x0000A4B901079F7D AS DateTime), 1, CAST(0x0000A4B901089A24 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (16, 2, N'Media Book New', N'Media Book New', 1, CAST(0x0000A4B901079F89 AS DateTime), 1, CAST(0x0000A4B901089F1A AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 3, N'Media Book', N'Media', 1, CAST(0x0000A4B901087ED1 AS DateTime), 1, CAST(0x0000A4B901098E55 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (18, 10026, N'Media Book', N'Media Book', 1, CAST(0x0000A4B901079F7D AS DateTime), 1, CAST(0x0000A4B901089A24 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (19, 10026, N'Media Book New', N'Media Book New', 1, CAST(0x0000A4B901079F89 AS DateTime), 1, CAST(0x0000A4B901089F1A AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (20, 2, N'Media Book', N'Media Book', 1, CAST(0x0000A4B90125630B AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (21, 2, N'Media Book New', N'Media Book New', 1, CAST(0x0000A4B901256317 AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (22, 2, N'Media Book', N'Media Book', 1, CAST(0x0000A4B901257089 AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (23, 2, N'Media Book New', N'Media Book New', 1, CAST(0x0000A4B901257095 AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (24, 10026, N'Media Book', N'Media Book', 1, CAST(0x0000A4B901258122 AS DateTime), 1, CAST(0x0000A4B901269075 AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (25, 10026, N'Media Book', N'Media Book', 1, CAST(0x0000A4B90125A140 AS DateTime), 1, CAST(0x0000A4B90126B08C AS DateTime), 1)
INSERT [dbo].[BookMediaReviews] ([IID], [BookID], [MediaName], [MediaComments], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (26, 10026, N'Media Book', N'Media Book', 1, CAST(0x0000A4B90125ED7C AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BookMediaReviews] OFF
SET IDENTITY_INSERT [dbo].[BookNews] ON 

INSERT [dbo].[BookNews] ([IID], [ImageUrl], [VideoLink], [Audio], [HeadLine], [NewsDescription], [PublishDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'', N'http://www.dailymotion.com/video/x2rp0ol_l-apres-seance-mad-max-fury-road_shortfilms', N'http://www.dailymotion.com/video/x2rp0ol_l-apres-seance-mad-max-fury-road_shortfilms', N'Bishwa Sahitya Kendra opens online book reading programme', N'<p>Bishwa Sahitya Kendra (BSK) on Wednesday introduced an online-based book reading programme.<br /><br />The book reading site, Alor Pathshala, has been launched in a programme at Bangla motor Bishwa Sahitya Kendra.<br /><br />Education minister Nurul Islam Nahid inaugurated the programme.<br /><br />Readers can read Bishwashahitto kendra books for free at the website Alor Pathshala at (alorpathshala.org).</p>', CAST(0x0000A4C700000000 AS DateTime), 1, CAST(0x0000A4AA00A32D02 AS DateTime), 1, CAST(0x0000A4AD00F22F63 AS DateTime), 0)
INSERT [dbo].[BookNews] ([IID], [ImageUrl], [VideoLink], [Audio], [HeadLine], [NewsDescription], [PublishDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'', N'', N'', N'Clash between students-book sellers is inconceivable', N'<p>We filled with remorse when Dhaka University students clash with Nilkhet book sellers. The discontent started centring a very trivial incident. A student went to a bookstore to change a book that he was bought a few days earlier. The student and book seller got into altercation and eventually a fierce fighting erupted. The discontent could be solved through holding successful dialogue. But soon the clash spread over the whole area, continued for about two and half hours and left at least 15 injured.<br /><br />It is important to find out the offenders, but setting fire to books is not acceptable. This is inconceivable. It is expected that Dhaka University students will be more considerable. The two parties involved there, condemning each other. That should be resolved through investigating the incidents.&nbsp;<br /><br />If a street vendor does something wrong, should that be treated with brutal attack. Such behaviour is unexpected and condemnable. Earlier same sort of clashes took place between students and book sellers. All were settled, but return after an interval. It is mentionable that students cannot go without books and book sellers need students. They are made for each other. So, clashes between Dhaka University students and traders should take shape on no ground. Students should feel that they posses great dignity in society. This realisation can stop the revival of rivalry.</p>', CAST(0x0000A4EC00000000 AS DateTime), 1, CAST(0x0000A4AA00AFBCED AS DateTime), 1, CAST(0x0000A4AA00AFBCD4 AS DateTime), 0)
INSERT [dbo].[BookNews] ([IID], [ImageUrl], [VideoLink], [Audio], [HeadLine], [NewsDescription], [PublishDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'~/Image/BookNewsImage/20150601115134663831553325325.jpg', N'http://www.youtube.com/watch?v=siOHh0uzcuY', N'http://www.dailymotion.com/video/x2sitsu_a-jump-of-60-m-long-with-a-truck_auto', N'Clash between students-book sellers is inconceivable', N'<p>Celebrated actor Tauquir Ahmed is all set to direct a movie based on his own book, eight years after his last directorial venture Daruchini Dwip.<br /><br />The movie Agyatonama is based on a book Tauquir penned under the same name which was published in this year&#39;s Amar Ekushey Book Fair. The movie is going to be the fourth directorial project of this multi-dimensional artiste.<br />|<br />&quot;Initially, I planned a stage adaptation of my book Agyatonama, but later decided to make it a movie. The screenplay has already been completed,&quot; said the actor.<br /><br />The movie will focus on the life of Bangladeshi expatriates in the Middle East, Tauquir said, but he chose not to reveal the names of the casts.<br /><br />&quot;Let&#39;s save a few things for a surprise,&quot; he said.<br /><br />Tauquir already has another directorial project lined up. &quot;We have applied for government funds for this movie. If we get it, we will be able to start filming of the movie by the end of the year,&quot; he added.</p><p>Taukir made his directorial debut in 2004 with the critically acclaimed Joyjatra. His other directorial projects are - Rupkothar Golpo (2006) and Daruchini Dwip (2007).</p>', CAST(0x0000A4C200000000 AS DateTime), 1, CAST(0x0000A4AA00C299BF AS DateTime), 1, CAST(0x0000A4AA00C31C98 AS DateTime), 0)
INSERT [dbo].[BookNews] ([IID], [ImageUrl], [VideoLink], [Audio], [HeadLine], [NewsDescription], [PublishDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'~/Image/BookNewsImage/20150608124028661861553325325.jpg', N'http://www.youtube.com/watch?v=pSiIHe2uZ2w', N'http://ebanglalibrary.com/', N'Book', N'<p>A&nbsp;<strong>book</strong>&nbsp;is a set of written, printed, illustrated, or blank sheets, made of&nbsp;<a href="http://en.wikipedia.org/wiki/Ink">ink</a>,&nbsp;<a href="http://en.wikipedia.org/wiki/Paper">paper</a>,&nbsp;<a href="http://en.wikipedia.org/wiki/Parchment">parchment</a>, or other materials, fastened together to hinge at one side. A single sheet within a book is a&nbsp;<a href="http://en.wikipedia.org/wiki/Recto">leaf</a>, and each side of a leaf is a&nbsp;<a href="http://en.wikipedia.org/wiki/Page_(paper)">page</a>. A set of text-filled or illustrated pages produced in electronic format is known as an electronic book, or&nbsp;<a href="http://en.wikipedia.org/wiki/E-book">e-book</a>.</p><p>Books may also refer to works of literature, or a main division of such a work. In&nbsp;<a href="http://en.wikipedia.org/wiki/Library_and_information_science">library and information science</a>, a book is called a&nbsp;<a href="http://en.wikipedia.org/wiki/Monograph">monograph</a>, to distinguish it from serial&nbsp;<a href="http://en.wikipedia.org/wiki/Periodical">periodicals</a>&nbsp;such as&nbsp;<a href="http://en.wikipedia.org/wiki/Magazine">magazines</a>,&nbsp;<a href="http://en.wikipedia.org/wiki/Academic_journal">journals</a>&nbsp;or&nbsp;<a href="http://en.wikipedia.org/wiki/Newspaper">newspapers</a>. The body of all written works including books is&nbsp;<a href="http://en.wikipedia.org/wiki/Literature">literature</a>. In&nbsp;<a href="http://en.wikipedia.org/wiki/Novel">novels</a>&nbsp;and sometimes other types of books (for example, biographies), a book may be divided into several large sections, also called books (Book 1, Book 2, Book 3, and so on). An avid reader of books is a&nbsp;<a href="http://en.wikipedia.org/wiki/Bibliophilia">bibliophile</a>&nbsp;or colloquially,&nbsp;<em>bookworm</em>.</p><p>Antiquity</p><p>&nbsp;</p><p><a href="http://en.wikipedia.org/wiki/Sumerian_language">Sumerian language</a>&nbsp;cuneiform script<a href="http://en.wikipedia.org/wiki/Clay_tablet">clay tablet</a>, 2400&ndash;2200 BC</p><p>When&nbsp;<a href="http://en.wikipedia.org/wiki/History_of_writing">writing systems</a>&nbsp;were invented/created in&nbsp;<a href="http://en.wikipedia.org/wiki/Ancient_civilization">ancient civilizations</a>, nearly everything that could be written upon&mdash;stone,&nbsp;<a href="http://en.wikipedia.org/wiki/Clay_tablet">clay</a>, tree bark, metal sheets&mdash;was used for writing.The study of such inscriptions forms a major part of history. The study of inscriptions is known as<a href="http://en.wikipedia.org/wiki/Epigraphy">epigraphy</a>.&nbsp;<a href="http://en.wikipedia.org/wiki/History_of_the_alphabet">Alphabetic writing</a>&nbsp;emerged in&nbsp;<a href="http://en.wikipedia.org/wiki/Egypt">Egypt</a>&nbsp;. The Ancient Egyptians would often write on&nbsp;<a href="http://en.wikipedia.org/wiki/Papyrus">papyrus</a>, a plant grown along the Nile River. At first the words were not separated from each other (<em><a href="http://en.wikipedia.org/wiki/Scriptura_continua">scriptura continua</a></em>) and there was no&nbsp;<a href="http://en.wikipedia.org/wiki/Punctuation">punctuation</a>. Texts were written from right to left, left to right, and even so that alternate lines read in opposite directions. The technical term for this type of writing is &#39;<a href="http://en.wikipedia.org/wiki/Boustrophedon">boustrophedon</a>,&#39; which means literally &#39;ox-turning&#39; for the way a farmer drives an ox to plough his fields.[<em><a href="http://en.wikipedia.org/wiki/Wikipedia:Citation_needed">citation needed</a></em>]</p><p>Tablet</p><p>A tablet might be defined as a physically robust writing medium, suitable for casual transport and writing. See also&nbsp;<a href="http://en.wikipedia.org/wiki/Stylus">stylus</a>.</p><p><a href="http://en.wikipedia.org/wiki/Clay_tablet">Clay tablets</a>&nbsp;were just what they sound like: flattened and mostly dry pieces of clay that could be easily carried, and impressed with a ( possible dampened) stylus. They were used as a writing medium, especially for writing in&nbsp;<a href="http://en.wikipedia.org/wiki/Cuneiform">cuneiform</a>, throughout the&nbsp;<a href="http://en.wikipedia.org/wiki/Bronze_Age">Bronze Age</a>&nbsp;and well into the&nbsp;<a href="http://en.wikipedia.org/wiki/Iron_Age">Iron Age</a>.</p><p><a href="http://en.wikipedia.org/wiki/Wax_tablet">Wax tablets</a>&nbsp;were wooden planks covered in a thick enough coating of wax to record the impressions of a stylus. They were the normal writing material in schools, in accounting, and for taking notes. They had the advantage of being reusable: the wax could be melted, and reformed into a blank. The custom of binding several wax tablets together (Roman&nbsp;<em>pugillares</em>) is a possible precursor for modern books (i.e. codex).<a href="http://en.wikipedia.org/wiki/Book#cite_note-4">[4]</a>&nbsp;The etymology of the word codex (block of wood) also suggests that it may have developed from wooden wax tablets.<a href="http://en.wikipedia.org/wiki/Book#cite_note-5">[5]</a></p>', CAST(0x0000A4B800000000 AS DateTime), 1, CAST(0x0000A4B100CFDDF1 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BookNews] OFF
SET IDENTITY_INSERT [dbo].[BookNewsLetter] ON 

INSERT [dbo].[BookNewsLetter] ([IID], [UserEmail], [IsSubscribe], [SubscribeDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'azizur@oiio.com', 1, CAST(0x0000A4A501185ACF AS DateTime), 1, CAST(0x0000A4A501185AFF AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[BookNewsLetter] OFF
SET IDENTITY_INSERT [dbo].[BookOffer] ON 

INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 10025, N'Darun offer', 1, N'Special offer', 0, CAST(0x0000A4B900C6FBC1 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 2, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B900FDD849 AS DateTime), 1, CAST(0x0000A4B900FEE7A5 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 2, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B901079F98 AS DateTime), 1, CAST(0x0000A4B90108A71F AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 2, N'Offer', 0, N'', 1, CAST(0x0000A4B901079FA5 AS DateTime), 1, CAST(0x0000A4B90108AC53 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 3, N'Has', 0, N'', 1, CAST(0x0000A4B901087EDD AS DateTime), 1, CAST(0x0000A4B901098E55 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 10026, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B901079F98 AS DateTime), 1, CAST(0x0000A4B90108A71F AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 10026, N'Offer', 0, N'', 1, CAST(0x0000A4B901079FA5 AS DateTime), 1, CAST(0x0000A4B90108AC53 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 2, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B901256324 AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 2, N'Offer', 0, N'', 1, CAST(0x0000A4B901256330 AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 2, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B9012570A3 AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 2, N'Offer', 0, N'', 1, CAST(0x0000A4B9012570B1 AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 10026, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B90125812E AS DateTime), 1, CAST(0x0000A4B901269075 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 10026, N'Offer', 0, N'', 1, CAST(0x0000A4B901258140 AS DateTime), 1, CAST(0x0000A4B901269075 AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 10026, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B90125A14B AS DateTime), 1, CAST(0x0000A4B90126B08C AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (15, 10026, N'Offer', 0, N'', 1, CAST(0x0000A4B90125A15D AS DateTime), 1, CAST(0x0000A4B90126B08C AS DateTime), 1)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (16, 10026, N'Darun offer', 1, N'Special offer', 1, CAST(0x0000A4B90125ED8D AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
INSERT [dbo].[BookOffer] ([IID], [BookID], [OfferDescription], [HasSpecialOffer], [SpecialOfferDescription], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 10026, N'Offer', 0, N'', 1, CAST(0x0000A4B90125ED99 AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BookOffer] OFF
INSERT [dbo].[BookOrder] ([IID], [UserID], [Quantity], [Payment], [ShippingDate], [ShippingAddress], [TotalPrice], [ShippingCost], [LocationID], [UserComment], [AdditionalMobile], [PaymentStatusID], [ShippingStatusID], [OrderDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (0, NULL, 2, NULL, NULL, N'.dfglkdfjb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x0000A480000ED96C AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BookOtherStoreUrl] ON 

INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, N'http://ebook.com/', 1, CAST(0x0000A47000000000 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, 2, N'http://ebook.com/', 1, CAST(0x0000A47000000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10009, 10019, 1, N'https://www.ebook.com/book', 0, CAST(0x0000A4B900AA8997 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10010, 10019, 5, N'www.ebook.com', 0, CAST(0x0000A4B900AA9133 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10011, 10020, 1, N'www.ebook.com/book', 0, CAST(0x0000A4B900AC1654 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10012, 10022, 8, N'www.bookdispensary.com', 1, CAST(0x0000A4B900AD3855 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10014, 10025, 7, N'www.ebook.com/book', 0, CAST(0x0000A4B900C6DC8D AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10015, 2, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B900FDD819 AS DateTime), 1, CAST(0x0000A4B900FEE7A5 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10016, 2, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B901079F57 AS DateTime), 1, CAST(0x0000A4B901089095 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10017, 2, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B901079F6C AS DateTime), 1, CAST(0x0000A4B901089422 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10018, 3, 1, N'eBook.com', 1, CAST(0x0000A4B901087EC5 AS DateTime), 1, CAST(0x0000A4B901098E55 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10019, 10026, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B901079F57 AS DateTime), 1, CAST(0x0000A4B901089095 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10020, 10026, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B901079F6C AS DateTime), 1, CAST(0x0000A4B901089422 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10021, 2, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B9012562ED AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10022, 2, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B9012562FC AS DateTime), 1, CAST(0x0000A4B90126725F AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10023, 2, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B90125707E AS DateTime), 1, CAST(0x0000A4B901267FF2 AS DateTime), 0)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10024, 10026, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B901258109 AS DateTime), 1, CAST(0x0000A4B901269075 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10025, 10026, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B901258115 AS DateTime), 1, CAST(0x0000A4B901269075 AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10026, 10026, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B90125A122 AS DateTime), 1, CAST(0x0000A4B90126B08C AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10027, 10026, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B90125A132 AS DateTime), 1, CAST(0x0000A4B90126B08C AS DateTime), 1)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10028, 10026, 1, N'https://www.ebook.com/book', 1, CAST(0x0000A4B90125ED63 AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
INSERT [dbo].[BookOtherStoreUrl] ([IID], [BookID], [BookAvailableStoreID], [BookAvailableUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10029, 10026, 5, N'www.bookdispensary.com', 1, CAST(0x0000A4B90125ED6E AS DateTime), 1, CAST(0x0000A4B90126FCD7 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BookOtherStoreUrl] OFF
SET IDENTITY_INSERT [dbo].[BookPublisher] ON 

INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'A Prokasoni', N'~/Image/PublisherImage/2.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), 1, CAST(0x0000A48100243101 AS DateTime), 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'oiio Prokasoni', N'~/Image/PublisherImage/2_d.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), 1, CAST(0x0000A481002DE06A AS DateTime), 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'C Prokasoni', N'~/Image/PublisherImage/2_c.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'Prokasoni', N'~/Image/PublisherImage/2_b.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'Prokasoni', N'~/Image/PublisherImage/2_c.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, N'C Prokasoni', N'~/Image/PublisherImage/2_c.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, N'Prokasoni', N'~/Image/PublisherImage/2_b.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, N'Prokasoni', N'~/Image/PublisherImage/2_c.png', N'cvgnbmn,', NULL, N'zdxfvchbvgm', 1, CAST(0x0000A47E01720971 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[BookPublisher] ([IID], [PublisherName], [PublisherLogoUrl], [AwardAchieved], [WebsiteLink], [AboutPublisher], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, N'Sheba Prokashoni', N'~/Image/PublisherImage/Sheba Prokashoni.jpg', N'Masud Rana', NULL, N'Sheba Prokashoni ( সেবা প্রকাশনী) is a well-known publishing house in Dhaka, Bangladesh. It was founded by Qazi Anwar Hussain. Sheba''s books have enjoyed great popularity among young Bangladeshi readers, and it is particularly notable for its accessible translations of Western literary classics into the Bengali language', 1, CAST(0x0000A4B3010F854B AS DateTime), 1, CAST(0x0000A4B700D310D5 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BookPublisher] OFF
SET IDENTITY_INSERT [dbo].[CMSContent] ON 

INSERT [dbo].[CMSContent] ([IID], [CMSTypeID], [Title], [CMSDescription], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (1, 1, N'Up branch to easily missed by do', N'<p>Up branch to easily missed by do. Admiration considered acceptance too led one melancholy expression. Are will took form the nor true. Winding enjoyed minuter her letters evident use eat colonel. He attacks observe mr cottage inquiry am examine gravity. Are dear but near left was. Year kept on over so as this of. She steepest doubtful betrayed formerly him. Active one called uneasy our seeing see cousin tastes its. Ye am it formed indeed agreed relied piqued.&nbsp;</p><p>We diminution preference thoroughly if. Joy deal pain view much her time. Led young gay would now state. Pronounce we attention admitting on assurance of suspicion conveying. That his west quit had met till. Of advantage he attending household at do perceived. Middleton in objection discovery as agreeable. Edward thrown dining so he my around to.&nbsp;</p><p>Admiration stimulated cultivated reasonable be projection possession of. Real no near room ye bred sake if some. Is arranging furnished knowledge agreeable so. Fanny as smile up small. It vulgar chatty simple months turned oh at change of. Astonished set expression solicitude way admiration.&nbsp;</p><p>Old education him departure any arranging one prevailed. Their end whole might began her. Behaved the comfort another fifteen eat. Partiality had his themselves ask pianoforte increasing discovered. So mr delay at since place whole above miles. He to observe conduct at detract because. Way ham unwilling not breakfast furniture explained perpetual. Or mr surrounded conviction so astonished literature. Songs to an blush woman be sorry young. We certain as removal attempt.&nbsp;</p><p>Do commanded an shameless we disposing do. Indulgence ten remarkably nor are impression out. Power is lived means oh every in we quiet. Remainder provision an in intention. Saw supported too joy promotion engrossed propriety. Me till like it sure no sons.&nbsp;</p><p>Performed suspicion in certainty so frankness by attention pretended. Newspaper or in tolerably education enjoyment. Extremity excellent certainty discourse sincerity no he so resembled. Joy house worse arise total boy but. Elderly up chicken do at feeling is. Like seen drew no make fond at on rent. Behaviour extremely her explained situation yet september gentleman are who. Is thought or pointed hearing he.&nbsp;</p><p>On projection apartments unsatiable so if he entreaties appearance. Rose you wife how set lady half wish. Hard sing an in true felt. Welcomed stronger if steepest ecstatic an suitable finished of oh. Entered at excited at forming between so produce. Chicken unknown besides attacks gay compact out you. Continuing no simplicity no favourable on reasonably melancholy estimating. Own hence views two ask right whole ten seems. What near kept met call old west dine. Our announcing sufficient why pianoforte.&nbsp;</p><p>Next his only boy meet the fat rose when. Do repair at we misery wanted remove remain income. Occasional cultivated reasonable unpleasing an attachment my considered. Having ask and coming object seemed put did admire figure. Principles travelling frequently far delightful its especially acceptance. Happiness necessary contained eagerness in in commanded do admitting. Favourable continuing difficulty had her solicitude far. Nor doubt off widow all death aware offer. We will up able in both do sing.&nbsp;</p><p>Whole every miles as tiled at seven or. Wished he entire esteem mr oh by. Possible bed you pleasure civility boy elegance ham. He prevent request by if in pleased. Picture too and concern has was comfort. Ten difficult resembled eagerness nor. Same park bore on be. Warmth his law design say are person. Pronounce suspected in belonging conveying ye repulsive.&nbsp;</p><p>Do greatest at in learning steepest. Breakfast extremity suffering one who all otherwise suspected. He at no nothing forbade up moments. Wholly uneasy at missed be of pretty whence. John way sir high than law who week. Surrounded prosperous introduced it if is up dispatched. Improved so strictly produced answered elegance is.&nbsp;</p>', N'~/Image/CMSImage/20150602154938553993553325325.jpg', 1, CAST(0x0000A4AB00FFC8C2 AS DateTime), 1, CAST(0x0000A4AB0103F821 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CMSContent] OFF
SET IDENTITY_INSERT [dbo].[Competition] ON 

INSERT [dbo].[Competition] ([IID], [CompetitionTypeID], [Title], [CompetitionStartDate], [CompetitionEndDate], [Description], [UploadFile], [ImageUrl], [LocationID], [SeasonID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 1, N'T2T', CAST(0x0000A4B800000000 AS DateTime), CAST(0x0000A43700000000 AS DateTime), N'Get ready for Spring with Marie Kondo''s Life-Changing Magic of Tidying and Lakeland.Transform your home into a permanently clear 
and clutter-free space with the incredible KonMari Method. Japan''s expert declutterer and professional cleaner Marie Kond...Get ready for Spring by winning a copy of Marie Kondo''s Life-Changing Magic of Tidying and a tidying...', N'', N'~/Image/Compitition/dota.jpg', 1, N'1', 1, CAST(0x0000A43700000000 AS DateTime), 1, CAST(0x0000A4B800EFC338 AS DateTime), 0)
INSERT [dbo].[Competition] ([IID], [CompetitionTypeID], [Title], [CompetitionStartDate], [CompetitionEndDate], [Description], [UploadFile], [ImageUrl], [LocationID], [SeasonID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 2, N'Full', CAST(0x0000A43700000000 AS DateTime), CAST(0x0000A4B800000000 AS DateTime), N'Get ready for Spring with Marie Kondo''s Life-Changing Magic of Tidying and Lakeland.Transform your home into a permanently clear 
and clutter-free space with the incredible KonMari Method. Japan''s expert declutterer and professional cleaner Marie Kond...', N'', N'~/Image/Compitition/wcg.jpg', 1, N'2', 1, CAST(0x0000A43700000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Competition] ([IID], [CompetitionTypeID], [Title], [CompetitionStartDate], [CompetitionEndDate], [Description], [UploadFile], [ImageUrl], [LocationID], [SeasonID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 3, N'Part', CAST(0x0000A4B800000000 AS DateTime), CAST(0x0000A43700000000 AS DateTime), N'', N'', N'~/Image/Compitition/dota.jpg', 2, N'3', 1, CAST(0x0000A43700000000 AS DateTime), 1, CAST(0x0000A4B800F43867 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Competition] OFF
SET IDENTITY_INSERT [dbo].[CompetitionRegistration] ON 

INSERT [dbo].[CompetitionRegistration] ([IID], [UploadFile], [ContestantId], [CompetitionID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, NULL, 1, 3, 1, CAST(0x0000A54D00000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CompetitionRegistration] ([IID], [UploadFile], [ContestantId], [CompetitionID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, NULL, 1, 6, 1, CAST(0x0000A3E000000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CompetitionRegistration] ([IID], [UploadFile], [ContestantId], [CompetitionID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'~/Image/Compitition/ContestantFile/3_5_61', 5, 3, 5, CAST(0x0000A4B301253334 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CompetitionRegistration] ([IID], [UploadFile], [ContestantId], [CompetitionID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'~/Image/Compitition/ContestantFile/3_6_15.png', 6, 3, 6, CAST(0x0000A4B30126AA9A AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CompetitionRegistration] ([IID], [UploadFile], [ContestantId], [CompetitionID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, N'~/Image/Compitition/ContestantFile/3_7_55.jpg', 7, 3, 7, CAST(0x0000A4B30128731D AS DateTime), 7, CAST(0x0000A4B30128A10D AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[CompetitionRegistration] OFF
SET IDENTITY_INSERT [dbo].[Contestant] ON 

INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, NULL, 1, 1, N'mahbub', N'mahbub.apece@gmail.com', N'/fj8iZ8oUMXzM8ULFr0j8w==', N'OiiOPasswordLock', 1, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, NULL, 1, 1, N'Mahbubur rahaman', N'mjs@gmail.com', N'/fj8iZ8oUMXzM8ULFr0j8w==', NULL, 1, 0, CAST(0x0000A4B30121290B AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, NULL, 1, 1, N'Mahbubur rahaman', N'mjs1@gmail.com', N'6M5PbkKtzdhfpoJu8bWCmw==', NULL, 1, 0, CAST(0x0000A4B30122C12C AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, NULL, 1, 1, N'Mahbubur rahaman', N'mjs2@gmail.com', N'6M5PbkKtzdhfpoJu8bWCmw==', NULL, 1, 0, CAST(0x0000A4B301241815 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, NULL, 1, 1, N'Mahbubur rahaman', N'mjs3@gmail.com', N'6M5PbkKtzdhfpoJu8bWCmw==', NULL, 1, 0, CAST(0x0000A4B301252CD1 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, NULL, 0, 1, N'Mahbubur rahaman', N'mjs4@gmail.com', N'6M5PbkKtzdhfpoJu8bWCmw==', NULL, 1, 0, CAST(0x0000A4B30126A9A1 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Contestant] ([IID], [PhoneNo], [IsEmail], [ProfessionID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, NULL, 1, 1, N'Mahbubur rahaman', N'1234@gmail.com', N'6M5PbkKtzdhfpoJu8bWCmw==', NULL, 1, 0, CAST(0x0000A4B3012872FC AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Contestant] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'01', N'Bangladesh', N'+88', 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'+91', N'India', NULL, 1, CAST(0x0000A4B200A3DA05 AS DateTime), 1, CAST(0x0000A4B200A4086A AS DateTime), 1)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'+91', N'India', NULL, 1, CAST(0x0000A4B200A41900 AS DateTime), 1, CAST(0x0000A4B30112E4C6 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([IID], [CountryID], [DivisionOrStateID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, N'01', N'Kurigram', 1, CAST(0x0000A4B200C25F50 AS DateTime), 1, CAST(0x0000A4B200E9C502 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[DivisionOrState] ON 

INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'Rangpor', N'Rajshahi', 1, CAST(0x0000A4B200AF44D3 AS DateTime), 1, CAST(0x0000A4B30118F08C AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[DivisionOrState] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([IID], [CountryID], [DistrictID], [SubDistrictID], [PoliceStationID], [PostOfficeID], [CurrentLocation], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemove]) VALUES (1, 1, 1, NULL, 1, 1, N'No Region', 1, CAST(0x0000A4B700000000 AS DateTime), 1, CAST(0x0000A4B800F2F366 AS DateTime), 0)
INSERT [dbo].[Location] ([IID], [CountryID], [DistrictID], [SubDistrictID], [PoliceStationID], [PostOfficeID], [CurrentLocation], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemove]) VALUES (2, 1, 1, NULL, 1, 1, N'No specified', 1, CAST(0x0000A4B7010BB483 AS DateTime), 1, CAST(0x0000A4B800F2FEE3 AS DateTime), 0)
INSERT [dbo].[Location] ([IID], [CountryID], [DistrictID], [SubDistrictID], [PoliceStationID], [PostOfficeID], [CurrentLocation], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemove]) VALUES (3, 1, 1, NULL, 1, 1, N'Panchagarh', 1, CAST(0x0000A4B800F3A72B AS DateTime), 1, CAST(0x0000A4B800F3BBC5 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Location] OFF
SET IDENTITY_INSERT [dbo].[OiiOBook] ON 

INSERT [dbo].[OiiOBook] ([IID], [CompanyName], [Email], [Logo], [LoginLogo], [Address], [Phone], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (2, N'OiiO international', N'support@oiiointernational.com', N'Images/Interfaces/logo.png', N'Images/Interfaces/logo.png', N'Gazi Bhabhan', N'01715209894', N'Copyright © 2015 OiiO International. All rights reserved.', 1, CAST(0x0000A4AB00CA1755 AS DateTime), 1, CAST(0x0000A4AB00CAB269 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[OiiOBook] OFF
SET IDENTITY_INSERT [dbo].[PoliceStation] ON 

INSERT [dbo].[PoliceStation] ([IID], [CountryID], [DivisionOrStateID], [DistrictID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, 1, N'01', N'Kurigram police Station', 1, CAST(0x0000A4B200CF6EFB AS DateTime), 1, CAST(0x0000A4B2012167F2 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PoliceStation] OFF
SET IDENTITY_INSERT [dbo].[PostOffice] ON 

INSERT [dbo].[PostOffice] ([IID], [Name], [Code], [PoliceStationID], [SubDistrictID], [DistrictID], [DivisionOrStateID], [CountryID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'Kurigram  Office', N'02', 1, NULL, 1, 1, 1, 1, CAST(0x0000A4B2010468A7 AS DateTime), 1, CAST(0x0000A4B201257F14 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PostOffice] OFF
SET IDENTITY_INSERT [dbo].[Profession] ON 

INSERT [dbo].[Profession] ([IID], [Type], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 4, N'Student', N'nice', 1, CAST(0x0000A46B01038EB7 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Profession] OFF
SET IDENTITY_INSERT [dbo].[UrlWFList] ON 

INSERT [dbo].[UrlWFList] ([IID], [ModuleName], [ModuleSerialNo], [UrlWFName], [UrlWFSerialNo], [UrlWFDisplayName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'MemberInformation', 2, N'dada', 322, N'ddddd', 1, CAST(0x0000A4B300C7458C AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[UrlWFList] OFF
SET IDENTITY_INSERT [dbo].[UserGroup] ON 

INSERT [dbo].[UserGroup] ([IID], [Name], [TypeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'admin', 1, 1, CAST(0x0000A54600000000 AS DateTime), 1, CAST(0x0000A4B20129A174 AS DateTime), 0)
INSERT [dbo].[UserGroup] ([IID], [Name], [TypeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'', 3, 1, CAST(0x0000A4B2010CF0CC AS DateTime), 1, CAST(0x0000A4B2010DF10D AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserGroup] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([IID], [UserGroupID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [IsEmail], [PhoneNo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 1, N'Marzia', N'jui@oiio.com', N'/fj8iZ8oUMXzM8ULFr0j8w==', NULL, 1, 0, NULL, 1, CAST(0x0000A46B01038EB7 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([IID], [UserGroupID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [IsEmail], [PhoneNo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 1, N'First Second', N'firstSecond@yahoo.com', N'/fj8iZ8oUMXzM8ULFr0j8w==', N'OiiOPasswordLock', 1, 0, N'123456789', 0, CAST(0x0000A4A900D23BF2 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[UserInfo] ([IID], [UserGroupID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [IsEmail], [PhoneNo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10008, 1, NULL, N'yahoo.yahoo@gmail.com', N'LsUEq9cSFPG5ezZ+UOHmyA==', N'OiiOPasswordLock', 1, 0, NULL, 1, CAST(0x0000A4B300B42F70 AS DateTime), 1, CAST(0x0000A4B300BFEA08 AS DateTime), 0)
INSERT [dbo].[UserInfo] ([IID], [UserGroupID], [UserName], [LoginName], [LoginPassword], [Salt], [IsActiveUser], [IsEmail], [PhoneNo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10010, 1, NULL, N'yahoo@gmail.com', N'eLr7FX8uXSqblkQ/6hEIlg==', N'OiiOPasswordLock', 0, 0, NULL, 1, CAST(0x0000A4B300C05068 AS DateTime), 1, CAST(0x0000A4B300C26CA3 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
SET IDENTITY_INSERT [dbo].[UserWFPermission] ON 

INSERT [dbo].[UserWFPermission] ([IID], [UserGroupID], [UrlWFListID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 1, 2, 1, CAST(0x0000A4B300C750C9 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserWFPermission] OFF
SET IDENTITY_INSERT [dbo].[VisitorCounter] ON 

INSERT [dbo].[VisitorCounter] ([IID], [TotalVisitor], [VisitDate]) VALUES (1, 586, NULL)
SET IDENTITY_INSERT [dbo].[VisitorCounter] OFF
SET IDENTITY_INSERT [dbo].[VisitorInfo] ON 

INSERT [dbo].[VisitorInfo] ([IID], [IPAddress], [IPType], [IsRemoved]) VALUES (1, N'::1', N'Real IP   ', 0)
SET IDENTITY_INSERT [dbo].[VisitorInfo] OFF
SET IDENTITY_INSERT [dbo].[VisitorInfoDetails] ON 

INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (1, 1, CAST(0x0000A477016B01B0 AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (2, 1, CAST(0x0000A477016B32E8 AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (3, 1, CAST(0x0000A477016B45A8 AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (4, 1, CAST(0x0000A477016CD2EC AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (5, 1, CAST(0x0000A477016D2AD0 AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (6, 1, CAST(0x0000A477016D46F0 AS DateTime), 0)
INSERT [dbo].[VisitorInfoDetails] ([IID], [VisitorInfoID], [AccessDateTime], [IsRemoved]) VALUES (7, 1, CAST(0x0000A47701855524 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[VisitorInfoDetails] OFF
ALTER TABLE [dbo].[AdGiver] ADD  CONSTRAINT [DF_AdGivger_TotalPostNo]  DEFAULT ((0)) FOR [TotalPostNo]
GO
ALTER TABLE [dbo].[AdGiverTracing] ADD  CONSTRAINT [DF_AdGiverTracing_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[BookNewsLetter] ADD  CONSTRAINT [DF_OiiONewsLetter_IsSubscribe]  DEFAULT ((0)) FOR [IsSubscribe]
GO
ALTER TABLE [dbo].[CMSContent] ADD  CONSTRAINT [DF_CMSContent_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Contestant] ADD  CONSTRAINT [DF_Contestant_IsEmail_1]  DEFAULT ((0)) FOR [IsEmail]
GO
ALTER TABLE [dbo].[OiiOBook] ADD  CONSTRAINT [DF_OiiOBook_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[OiiOOthers] ADD  CONSTRAINT [DF_OiiOOthers_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserGroup] ADD  CONSTRAINT [DF_UserGroup_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsEmail_1]  DEFAULT ((0)) FOR [IsEmail]
GO
ALTER TABLE [dbo].[VisitorCounter] ADD  CONSTRAINT [DF_VisitorCounter_TotalVisitor]  DEFAULT ((0)) FOR [TotalVisitor]
GO
ALTER TABLE [dbo].[VisitorInfo] ADD  CONSTRAINT [DF_VisitorInfo_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[VisitorInfoDetails] ADD  CONSTRAINT [DF_VisitorInfoDetails_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[AdGiverTracing]  WITH CHECK ADD  CONSTRAINT [FK_AdGiverTracing_AdGiver] FOREIGN KEY([IID])
REFERENCES [dbo].[AdGiver] ([IID])
GO
ALTER TABLE [dbo].[AdGiverTracing] CHECK CONSTRAINT [FK_AdGiverTracing_AdGiver]
GO
ALTER TABLE [dbo].[AdGiverTracing]  WITH CHECK ADD  CONSTRAINT [FK_AdGiverTracing_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([IID])
GO
ALTER TABLE [dbo].[AdGiverTracing] CHECK CONSTRAINT [FK_AdGiverTracing_Book]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookAuthor] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[BookAuthor] ([IID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookAuthor]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BooKCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[BooKCategory] ([IID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BooKCategory]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookPublisher] FOREIGN KEY([PublisherID])
REFERENCES [dbo].[BookPublisher] ([IID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookPublisher]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([IID])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Country]
GO
ALTER TABLE [dbo].[BookMediaReviews]  WITH CHECK ADD  CONSTRAINT [FK_BookMediaReviews_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([IID])
GO
ALTER TABLE [dbo].[BookMediaReviews] CHECK CONSTRAINT [FK_BookMediaReviews_Book]
GO
ALTER TABLE [dbo].[BookOffer]  WITH CHECK ADD  CONSTRAINT [FK_BookOffer_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([IID])
GO
ALTER TABLE [dbo].[BookOffer] CHECK CONSTRAINT [FK_BookOffer_Book]
GO
ALTER TABLE [dbo].[BookOrderItem]  WITH CHECK ADD  CONSTRAINT [FK_BookOrderItem_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([IID])
GO
ALTER TABLE [dbo].[BookOrderItem] CHECK CONSTRAINT [FK_BookOrderItem_Book]
GO
ALTER TABLE [dbo].[BookOtherStoreUrl]  WITH CHECK ADD  CONSTRAINT [FK_BookOtherStoreUrl_Book1] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([IID])
GO
ALTER TABLE [dbo].[BookOtherStoreUrl] CHECK CONSTRAINT [FK_BookOtherStoreUrl_Book1]
GO
ALTER TABLE [dbo].[CompetitionRegistration]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionRegistration_Competition] FOREIGN KEY([CompetitionID])
REFERENCES [dbo].[Competition] ([IID])
GO
ALTER TABLE [dbo].[CompetitionRegistration] CHECK CONSTRAINT [FK_CompetitionRegistration_Competition]
GO
ALTER TABLE [dbo].[CompetitionRegistration]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionRegistration_Contestant] FOREIGN KEY([ContestantId])
REFERENCES [dbo].[Contestant] ([IID])
GO
ALTER TABLE [dbo].[CompetitionRegistration] CHECK CONSTRAINT [FK_CompetitionRegistration_Contestant]
GO
ALTER TABLE [dbo].[Contestant]  WITH CHECK ADD  CONSTRAINT [FK_Contestant_Profession] FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[Profession] ([IID])
GO
ALTER TABLE [dbo].[Contestant] CHECK CONSTRAINT [FK_Contestant_Profession]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_DivisionOrState] FOREIGN KEY([DivisionOrStateID])
REFERENCES [dbo].[DivisionOrState] ([IID])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_DivisionOrState]
GO
ALTER TABLE [dbo].[DivisionOrState]  WITH CHECK ADD  CONSTRAINT [FK_DivisionOrState_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([IID])
GO
ALTER TABLE [dbo].[DivisionOrState] CHECK CONSTRAINT [FK_DivisionOrState_Country]
GO
ALTER TABLE [dbo].[DivisionOrState]  WITH CHECK ADD  CONSTRAINT [FK_DivisionOrState_Country1] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([IID])
GO
ALTER TABLE [dbo].[DivisionOrState] CHECK CONSTRAINT [FK_DivisionOrState_Country1]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([IID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Country]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([IID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_District]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_PoliceStation] FOREIGN KEY([PoliceStationID])
REFERENCES [dbo].[PoliceStation] ([IID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_PoliceStation]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_PostOffice] FOREIGN KEY([PostOfficeID])
REFERENCES [dbo].[PostOffice] ([IID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_PostOffice]
GO
ALTER TABLE [dbo].[PoliceStation]  WITH CHECK ADD  CONSTRAINT [FK_PoliceStation_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([IID])
GO
ALTER TABLE [dbo].[PoliceStation] CHECK CONSTRAINT [FK_PoliceStation_District]
GO
ALTER TABLE [dbo].[PostOffice]  WITH CHECK ADD  CONSTRAINT [FK_PostOffice_PoliceStation] FOREIGN KEY([PoliceStationID])
REFERENCES [dbo].[PoliceStation] ([IID])
GO
ALTER TABLE [dbo].[PostOffice] CHECK CONSTRAINT [FK_PostOffice_PoliceStation]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroup] ([IID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserGroup]
GO
ALTER TABLE [dbo].[UserWFPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserWFPermission_UrlWFList] FOREIGN KEY([UrlWFListID])
REFERENCES [dbo].[UrlWFList] ([IID])
GO
ALTER TABLE [dbo].[UserWFPermission] CHECK CONSTRAINT [FK_UserWFPermission_UrlWFList]
GO
ALTER TABLE [dbo].[UserWFPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserWFPermission_UserGroup] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroup] ([IID])
GO
ALTER TABLE [dbo].[UserWFPermission] CHECK CONSTRAINT [FK_UserWFPermission_UserGroup]
GO
ALTER TABLE [dbo].[VisitorInfoDetails]  WITH CHECK ADD  CONSTRAINT [FK_VisitorInfoDetails_VisitorInfo] FOREIGN KEY([VisitorInfoID])
REFERENCES [dbo].[VisitorInfo] ([IID])
GO
ALTER TABLE [dbo].[VisitorInfoDetails] CHECK CONSTRAINT [FK_VisitorInfoDetails_VisitorInfo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Private, Business, Organization.... etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdGiver', @level2type=N'COLUMN',@level2name=N'ClientTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Personal, OrganiztionOrCompany' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdGiver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'eBook,Audio,PaperBack,eBookAndAudio,AudioAndPaperBack,PaperBackAndeBook,All,None,..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Book', @level2type=N'COLUMN',@level2name=N'BookWishTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fiction,Non-Fiction...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BooKCategory', @level2type=N'COLUMN',@level2name=N'ParentCategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enum:Amazon,RandomHouse,...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookOtherStoreUrl', @level2type=N'COLUMN',@level2name=N'BookAvailableStoreID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'WritersCompetition,NovelCompetition,ShortStoryCompetition,PoemCompetitions,GeneralCompetition..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Competition', @level2type=N'COLUMN',@level2name=N'CompetitionTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Spring,Summer,Winter,...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Competition', @level2type=N'COLUMN',@level2name=N'SeasonID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password Salt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contestant', @level2type=N'COLUMN',@level2name=N'Salt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'To display table data using web service' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'To display table data using web service' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DivisionOrState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'To display table data using web service' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PoliceStation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Self-Employeed, Employee, Businessman,Author,Student,Poet..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profession', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Self-Employeed->Doctor, Engineer............, ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profession', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ControlUser, Management, AddGiver' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password Salt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Salt'
GO
USE [master]
GO
ALTER DATABASE [OiiOBook] SET  READ_WRITE 
GO
