USE [master]
GO
/****** Object:  Database [OiiOMart_Live]    Script Date: 6/23/2015 12:42:05 PM ******/
CREATE DATABASE [OiiOMart_Live]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OiiOMart_Live', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OiiOMart_Live.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OiiOMart_Live_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OiiOMart_Live_log.ldf' , SIZE = 18240KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OiiOMart_Live] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OiiOMart_Live].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OiiOMart_Live] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET ARITHABORT OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [OiiOMart_Live] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OiiOMart_Live] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OiiOMart_Live] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OiiOMart_Live] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OiiOMart_Live] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET RECOVERY FULL 
GO
ALTER DATABASE [OiiOMart_Live] SET  MULTI_USER 
GO
ALTER DATABASE [OiiOMart_Live] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OiiOMart_Live] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OiiOMart_Live] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OiiOMart_Live] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OiiOMart_Live', N'ON'
GO
USE [OiiOMart_Live]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromUserGroup]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
Create PROCEDURE [dbo].[DeleteFromUserGroup]
	
	(
		@id bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	Delete from UserGroup where IID=@id;
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteGuideLineDetailByGuideLineIID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGuideLineDetailByGuideLineIID]
	
	(
		@LoanIID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  dbo.[GuideLineDetail] 
	SET dbo.[GuideLineDetail].IsRemoved = 1
	where dbo.[GuideLineDetail].GuideLineID = @LoanIID
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteGuideLineDetailByLoanIID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGuideLineDetailByLoanIID]
	
	(
		@LISchemaID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  dbo.[GuideLineDetail] 
	SET dbo.[GuideLineDetail].IsRemoved = 1
	where dbo.[GuideLineDetail].GuideLineID = @LISchemaID
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteLiFeatureByLIIID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLiFeatureByLIIID]
	
	(
		@LISchemaID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  dbo.[LIApplicableFeature] 
	SET dbo.[LIApplicableFeature].IsRemoved = 1
	where dbo.[LIApplicableFeature].LISchemaID = @LISchemaID
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteLoanFeatureByLoanIID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteLoanFeatureByLoanIID]
	
	(
		@LoanIID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  dbo.[LoanFeature] 
	SET dbo.[LoanFeature].IsRemoved = 1
	where dbo.[LoanFeature].LoanInfoID = @LoanIID
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteMPFeatureByMobilePhoneInfoID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMPFeatureByMobilePhoneInfoID]
	
	(
		@MobilePhoneInfoIID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  MPFeature
	SET MPFeature.IsRemoved = 1
	where MPFeature.MobilePhoneID = @MobilePhoneInfoIID
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllCardNameAccordingToBank]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCardNameAccordingToBank]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT (comp.Name + '----' +  card.Name) As CARD, card.IID
	FROM
	CompanyInfo comp
	Join 
	CardInfo card
	ON comp.IID= card.CompanyInfoID 

END


GO
/****** Object:  StoredProcedure [dbo].[GetCardInfoPageWise]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
=================================================

Mahbub-
07-Apr-2015

==================================================

=================================================

exec [GetCardInfoPageWise]
@PageIndex=2
,@PageSize=4
,@PageCount=10


==================================================
*/
CREATE PROCEDURE [dbo].[GetCardInfoPageWise]
      @PageIndex INT = 1
      ,@PageSize INT = 10
      ,@PageCount INT OUTPUT
AS
BEGIN
      SET NOCOUNT ON;
      SELECT ROW_NUMBER() OVER
            (
                  ORDER BY [IID] ASC
            )AS RowNumber
      ,[IID]
      ,[CompanyInfoID]
      ,[Name]
      ,[Description]
      ,[CardTypeID]
      ,[BalanceTypeID]
      ,[CardLogoUrl]
      ,[APR]
      ,[APRDescription]
      ,[MinimumLimitAmt]
      ,[MaximumLimitAmt]
      ,[AnnualFeePayment]
      ,[RewardNote]
      ,[RewardCompanyLogoUrl]
      ,[CashbackEarnedAmt]
      ,[CashbackEarnedNote]
      ,[WholeWorldUsageFeePer]
      ,[UsedRemarkedPoint]
      ,[PostAdDate]
      ,[PostLastDisplayDate]
      ,[PaymentAmt]
      ,[IsVerified]
      ,[VerifiedBy]
      ,[RedirectUrl]
      ,[TotalVisitor]
      ,[IsPostAdExtended]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
    INTO #Results
      FROM [CardInfo]
     
      DECLARE @RecordCount INT
      SELECT @RecordCount = COUNT(*) FROM #Results
 
      SET @PageCount = CEILING(CAST(@RecordCount AS DECIMAL(10, 2)) / CAST(@PageSize AS DECIMAL(10, 2)))
      PRINT       @PageCount
           
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
     
      DROP TABLE #Results
END

GO
/****** Object:  StoredProcedure [dbo].[GetGasCylienderListBySearch]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGasCylienderListBySearch]
(	
	@companyID	int,
	@districtId bigint,
	@policeStationId bigint,
	@amountOfGas int 
) 

AS
BEGIN
	 SET NOCOUNT ON;

	 BEGIN	
	 select *from
	 (SELECT
	 GCMAP.IID as id,
	 GC.IID,
	 CI.Name as CompanyName,
	 CI.LogoUrl,
	 GC.WeightOfGas,
	 GC.WeightOfContainer,
	 GC.RetailPrice,
	 GC.ImageUrl ,
	 CI.WebAddress,
	 GC.RedirectUrl,
	 ROW_NUMBER() OVER (PARTITION BY GC.IID ORDER BY GC.IID) AS RowNumber
	 FROM GasCyliender GC
	 inner join CompanyInfo CI on GC.CompanyInfoID=CI.IID
	 inner join GasCylinderAndDealerInfoMapping GCMAP on GC.IID=GCMAP.GasCylinderID	 
	 left join GasDealerInfo GD on GCMAP.GasDealerInfoID=GD.IID	 
	 left join District DS on GD.DistrictID=DS.IID
	 left join PoliceStation PS on DS.IID=PS.DistrictID
	 WHERE  GC.IsRemoved='false'
	 AND(@companyID is null or GC.CompanyInfoID=@companyID)
	 AND(@districtId is null or GD.DistrictID=@districtId)
	 AND(@policeStationId is null or PS.IID=@policeStationId)
	 AND(@amountOfGas is null or GC.WeightOfGas=@amountOfGas)) as a
	 where a.RowNumber=1
	 

	 END	 

END

GO
/****** Object:  StoredProcedure [dbo].[GetMobileInfoListForSearch]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
exec [GetMobileInfoListForSearch]
    @manufactureID=null,
	@mpTypeID=null,
	@modelName=null,
	@talktime=null,
	@talktimeUnitId=null,
	@data=null,
	@dataUnitId=null,
	@montlyAmount=null,
	@networkProviderId=7

*/
CREATE PROCEDURE [dbo].[GetMobileInfoListForSearch]
(	
	@manufactureID int,
	@mpTypeID int,
	@modelName nvarchar(200),
	@talktime int,
	@talktimeUnitId int,
	@data decimal(10, 2),
	@dataUnitId int,
	@montlyAmount money,
	@networkProviderId int
) 
	
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN	
	select
	MPI.IID,
	MPT.TypeName as Name,
	MPI.PictureUrl,
	MPI.TotalTalkTime,
	MPI.TotalTextMessage,
	MPI.TotalUsableData,
	MPI.MonthlyInstallmentAmt,
	MPI.RedirectUrl,
	MPI.TalkTimeUnitID,
	MPI.UsableDataUnitID
	
	from MobilePhoneInfo MPI
	inner join CompanyInfo CI on CI.IID=MPI.CompanyInfoID
	inner join MPType MPT on MPT.CompanyInfoID=CI.IID
	where MPI.IsRemoved='false'
	and(@manufactureID is null or MPI.CompanyInfoID=@manufactureID)
	and(@mpTypeID is null or MPI.MPTypeID=@mpTypeID)
	and(@modelName is null or MPI.ModelName=@modelName)
	and(@talktime is null or MPI.TotalTalkTime=@talktime)
	and(@talktimeUnitId is null or MPI.TalkTimeUnitID=@talktimeUnitId)
	and(@data is null or MPI.TotalUsableData=@data)
	and(@dataUnitId is null or MPI.UsableDataUnitID=@dataUnitId)
	and(@montlyAmount is null or MPI.MonthlyInstallmentAmt=@montlyAmount)
	and(@networkProviderId is null or MPI.NetworkProviderID=@networkProviderId)
	

	 END	 

END

GO
/****** Object:  StoredProcedure [dbo].[GetServerDateTime]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertAllFeatureAndAllChildAllFeatureCartDetailsXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAllFeatureAndAllChildAllFeatureCartDetailsXML]
(	
	@AllFeatureXML ntext 
) 

AS
  DECLARE @docHandle int, @AllFeatureID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @AllFeatureXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[AllFeature]
  (
	   [BusinessTypeID]
      ,[BusinessTypeBreakdownID]
      ,[TitleName]
      ,[Description]
      ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  BusinessTypeID
      ,BusinessTypeBreakdownID
      ,TitleName
      ,Description
      ,ImageUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/AllFeature', 3) WITH ( 
  BusinessTypeID int
      ,BusinessTypeBreakdownID int
      ,TitleName nvarchar(500)
      ,Description nvarchar(999)
      ,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
	  )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @AllFeatureID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[AllFeatureDetail](
       [AllFeatureID]
      ,[TitleName]
      ,[Description]
      ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
	  )
   SELECT @AllFeatureID AS AllFeatureID   
      ,TitleName
      ,Description
      ,ImageUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/AllFeature/AllFeatureDetailColl/AllFeatureDetail', 3)   WITH 
   (
   AllNewsID bigint
      ,TitleName nvarchar(500)
      ,[Description] nvarchar(999)
      ,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
   
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

EXEC sp_xml_removedocument @docHandle SELECT @AllFeatureID AS [AllFeatureID]





GO
/****** Object:  StoredProcedure [dbo].[InsertAllNewsAndAllChildAllNewsCartDetailsXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAllNewsAndAllChildAllNewsCartDetailsXML]
(	
	@AllNewsXML ntext 
) 

AS
  DECLARE @docHandle int, @AllNewsID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @AllNewsXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[AllNews]
  (
	   [BusinessTypeID]
      ,[BusinessTypeBreakdownID]
      ,[TitleName]
      ,[Description]
      ,[ImageUrl]
      ,[ReleaseDate]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  BusinessTypeID
      ,BusinessTypeBreakdownID
      ,TitleName
      ,Description
      ,ImageUrl
      ,ReleaseDate
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/AllNews', 3) WITH ( 
  BusinessTypeID int
      ,BusinessTypeBreakdownID int
      ,TitleName nvarchar(500)
      ,Description nvarchar(999)
      ,ImageUrl nvarchar(999)
      ,ReleaseDate datetime
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
	  )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @AllNewsID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[AllNewsDetail](
       [AllNewsID]
      ,[TitleName]
      ,[Description]
      ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
	  )
   SELECT @AllNewsID AS AllNewsID   
      ,TitleName
      ,Description
      ,ImageUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/AllNews/AllNewsDetailColl/AllNewsDetail', 3)   WITH 
   (
   AllNewsID bigint
      ,TitleName nvarchar(500)
      ,Description nvarchar(999)
      ,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
   
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

EXEC sp_xml_removedocument @docHandle SELECT @AllNewsID AS [AllNewsID]





GO
/****** Object:  StoredProcedure [dbo].[InsertBDInternetAndChannelMappingChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertBDInternetAndChannelMappingChildXML]
(	
	@BDInternetAndChannelMappingXML ntext
) 

AS
  DECLARE @docHandle int, @BDInternetID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @BDInternetAndChannelMappingXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[BDInternet]
  (
	   [ProviderID]
      ,[TypeID]
      ,[PackageName]
      ,[PackageImageUrl]
      ,[NetSpeed]
      ,[NetSpeedUnitID]
      ,[DownloadSpeed]
      ,[DownloadSpeedUnitID]
	  ,[DataAmount]
      ,[NetGenerationID]
	  ,[ContractDuration]  /* Hasan Add 3 Field ContractDuration,ContractTypeID,  ContractNote  */
	  ,[ContractTypeID]
	  ,[ContractNote]
      ,[ChargeTypeID]
      ,[ChargeTypeNote]
      ,[ChargeAmount]
      ,[TotalChannelNo]
      ,[RedirectUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  ProviderID
      ,TypeID
      ,PackageName
      ,PackageImageUrl
      ,NetSpeed
      ,NetSpeedUnitID
      ,DownloadSpeed
      ,DownloadSpeedUnitID
	  ,DataAmount
      ,NetGenerationID
	  ,ContractDuration
	  ,ContractTypeID
	  ,ContractNote
      ,ChargeTypeID
      ,ChargeTypeNote
      ,ChargeAmount
      ,TotalChannelNo
      ,RedirectUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/BDInternet', 3) WITH ( 
	   ProviderID int
      ,TypeID int
      ,PackageName nvarchar(500)
      ,PackageImageUrl nvarchar(500)
      ,NetSpeed int
      ,NetSpeedUnitID int
      ,DownloadSpeed int
      ,DownloadSpeedUnitID int
	  ,DataAmount nvarchar(500)
      ,NetGenerationID int
	  ,ContractDuration	int
	  ,ContractTypeID int  
	  ,ContractNote	nvarchar(50)
      ,ChargeTypeID int
      ,ChargeTypeNote nvarchar(500)
      ,ChargeAmount money
      ,TotalChannelNo int
      ,RedirectUrl nvarchar(500)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @BDInternetID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[BDInternetAndChannelMapping](
       [BDInternetID]
      ,[BDChannelInfoID]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @BDInternetID AS BDInternetID
      ,BDChannelInfoID
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/BDInternet/BDInternetAndChannelMappingColl/BDInternetAndChannelMapping', 3)   WITH 
   (
    BDInternetID bigint
	  ,BDChannelInfoID int
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @BDInternetID AS [BDInternetID]





GO
/****** Object:  StoredProcedure [dbo].[InsertBICategoryAndChildCategoryXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertBICategoryAndChildCategoryXML]
(	
	@BICategoryXML ntext 
) 

AS
  DECLARE @docHandle int, @BICategoryID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @BICategoryXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[BICategory]
  (
	   [Name]
      ,[Note]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  Name
      ,Note
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/BICategory', 3) WITH ( 
  Name nvarchar(200)
      ,Note nvarchar(200)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
	  )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @BICategoryID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[BICategoryDetail](
       [BICategoryID]
      ,[Name]
      ,[Note]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
	  )
   SELECT @BICategoryID AS BICategoryID
      ,Name
      ,Note
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/BICategory/BICategoryDetailColl/BICategoryDetail', 3)   WITH 
   (
      BICategoryID bigint
      ,Name nvarchar(200)
      ,Note nvarchar(200)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit   
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

EXEC sp_xml_removedocument @docHandle SELECT @BICategoryID AS  [BICategoryID]





GO
/****** Object:  StoredProcedure [dbo].[InsertBiReceiverAndBiReceiverChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertBiReceiverAndBiReceiverChildXML]
(	
	@BiReceiverXML ntext 
) 

AS
  DECLARE @docHandle int, @BiReceiverID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @BiReceiverXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[BusinessInsuranceReceiver]
  (
	   [ApplicantID]
      ,[BICategoryDetailID]
      ,[BIBusinessAgeID]
      ,[YearWiseTurnoverAmt]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  ApplicantID
      ,BICategoryDetailID
      ,BIBusinessAgeID
      ,YearWiseTurnoverAmt
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/BusinessInsuranceReceiver', 3) WITH ( 
       ApplicantID bigint
      ,BICategoryDetailID bigint
      ,BIBusinessAgeID bigint
      ,YearWiseTurnoverAmt money
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
	  )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @BiReceiverID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[BusinessInsuranceReceiverDetail](
      [BusinessInsuranceReceiverID]
      ,[BIAmountRangeID]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
	  )
   SELECT @BiReceiverID AS BusinessInsuranceReceiverID
      ,BIAmountRangeID
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/BusinessInsuranceReceiver/BusinessInsuranceReceiverDetailColl/BusinessInsuranceReceiverDetail', 3)   WITH 
   (
       BusinessInsuranceReceiverID bigint
      ,BIAmountRangeID bigint
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit   
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

EXEC sp_xml_removedocument @docHandle SELECT @BiReceiverID AS [BusinessInsuranceReceiverID]





GO
/****** Object:  StoredProcedure [dbo].[InsertCardInfoAndAllFreatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertCardInfoAndAllFreatureChildXML]
(	
	@CardInfoXML ntext 
) 

AS
  DECLARE @docHandle int, @CardInfoID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @CardInfoXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[CardInfo]
  (
	   [CompanyInfoID]
      ,[Name]
      ,[Description]
      ,[CardTypeID]
      ,[BalanceTypeID]
      ,[CardLogoUrl]
      ,[APR]
      ,[APRDescription]
      ,[MinimumLimitAmt]
      ,[MaximumLimitAmt]
      ,[AnnualFeePayment]
      ,[RewardNote]
      ,[RewardCompanyLogoUrl]
      ,[CashbackEarnedAmt]
      ,[CashbackEarnedNote]
      ,[WholeWorldUsageFeePer]
      ,[UsedRemarkedPoint]
      ,[PostAdDate]
      ,[PostLastDisplayDate]
      ,[PaymentAmt]
      ,[IsVerified]
      ,[VerifiedBy]
      ,[RedirectUrl]
      ,[TotalVisitor]
      ,[IsPostAdExtended]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  CompanyInfoID
		  ,Name
		  ,Description
      ,CardTypeID
      ,BalanceTypeID
      ,CardLogoUrl
      ,APR
      ,APRDescription
      ,MinimumLimitAmt
      ,MaximumLimitAmt
      ,AnnualFeePayment
      ,RewardNote
      ,RewardCompanyLogoUrl
      ,CashbackEarnedAmt
      ,CashbackEarnedNote
      ,WholeWorldUsageFeePer
      ,UsedRemarkedPoint
      ,PostAdDate
      ,PostLastDisplayDate
      ,PaymentAmt
      ,IsVerified
      ,VerifiedBy
      ,RedirectUrl
      ,TotalVisitor
      ,IsPostAdExtended
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/CardInfo', 3) WITH ( 
  CompanyInfoID int
		  ,Name nvarchar(200)
		  ,Description nvarchar(500)
      ,CardTypeID int
      ,BalanceTypeID int
      ,CardLogoUrl nvarchar(2000)
      ,APR money
      ,APRDescription nvarchar(500)
      ,MinimumLimitAmt money
      ,MaximumLimitAmt money
      ,AnnualFeePayment money
      ,RewardNote nvarchar(500)
      ,RewardCompanyLogoUrl nvarchar(2000)
      ,CashbackEarnedAmt money
      ,CashbackEarnedNote nvarchar(500)
      ,WholeWorldUsageFeePer money
      ,UsedRemarkedPoint float
      ,PostAdDate datetime
      ,PostLastDisplayDate datetime
      ,PaymentAmt money
      ,IsVerified bit
      ,VerifiedBy bigint
      ,RedirectUrl nvarchar(2000)
      ,TotalVisitor int
      ,IsPostAdExtended bit
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @CardInfoID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[CardFeature](
   [CardInfoID]
      ,[Description]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @CardInfoID AS CardInfoID,
   Description
      ,CreatedBy
      ,CreatedDate

      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/CardInfo/CardFeatureColl/CardFeature', 3)   WITH 
   (
    CardInfoID bigint
	,Description nvarchar(500)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @CardInfoID AS [CardInfoID]





GO
/****** Object:  StoredProcedure [dbo].[InsertCarInsuranceFreatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertCarInsuranceFreatureChildXML]
(	
	@CarInsuranceFreatureXML ntext 
)

AS
  DECLARE @docHandle int, @CarInsuranceID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @CarInsuranceFreatureXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[CarInsurance]
  (
	   [CompanyInfoID]
      ,[CarInsuranceParameterID]
      ,[CarValueAmount]
      ,[FixedTotalAmount]
	  ,[FixedVoluntaryAmount]
	  ,[FixedCompulsoryAmount]
	  ,[AnnuallyGrossAmount]
	  ,[TotalMonth]
	  ,[InstallmentAmount]
	  ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT 
	   CompanyInfoID
      ,CarInsuranceParameterID
      ,CarValueAmount
      ,FixedTotalAmount
	  ,FixedVoluntaryAmount
	  ,FixedCompulsoryAmount
	  ,AnnuallyGrossAmount
	  ,TotalMonth
	  ,InstallmentAmount
	  ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/CarInsurance', 3) WITH ( 
	   CompanyInfoID int
      ,CarInsuranceParameterID int
      ,CarValueAmount money
      ,FixedTotalAmount money
	  ,FixedVoluntaryAmount money
	  ,FixedCompulsoryAmount money
	  ,AnnuallyGrossAmount money
	  ,TotalMonth int
	  ,InstallmentAmount money
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @CarInsuranceID = SCOPE_IDENTITY()
   ---Picture 
   INSERT INTO [dbo].[CarInsuranceFeature](
       [CarInsuranceID]
      ,[Description]
	  ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @CarInsuranceID
      
      ,Description
	  ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/CarInsurance/CarInsuranceFeatureColl/CarInsuranceFeature', 3)   WITH 
   (
       CarInsuranceID bigint
      ,Description nvarchar(500)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @CarInsuranceID AS [CarInsuranceID]





GO
/****** Object:  StoredProcedure [dbo].[InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXML]
(	
	@GasCylienderXML ntext 
) 

AS
  DECLARE @docHandle int, @GasCylienderID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @GasCylienderXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[GasCyliender]
  (
	   [CompanyInfoID]
      ,[AreaInfo]
      ,[WeightOfGas]
      ,[WeightOfContainer]
      ,[RetailPrice]
      ,[PriceNote]
      ,[ImageUrl]
      ,[RedirectUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  CompanyInfoID
      ,AreaInfo
      ,WeightOfGas
      ,WeightOfContainer
      ,RetailPrice
      ,PriceNote
      ,ImageUrl
      ,RedirectUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/GasCyliender', 3) WITH ( 
  CompanyInfoID int
      ,AreaInfo nvarchar(999)
      ,WeightOfGas float
      ,WeightOfContainer float
      ,RetailPrice money
      ,PriceNote nvarchar(500)
      ,ImageUrl nvarchar(999)
      ,RedirectUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
	  )
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @GasCylienderID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[GasCylinderAndDealerInfoMapping](
       [GasCylinderID]
      ,[GasDealerInfoID]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
	  )
   SELECT @GasCylienderID AS GasCylinderID
      ,GasDealerInfoID
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/GasCyliender/GasCylinderAndDealerInfoMappingColl/GasCylinderAndDealerInfoMapping', 3)   WITH 
   (
       GasCylinderID bigint
      ,GasDealerInfoID int
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit
   
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

EXEC sp_xml_removedocument @docHandle SELECT @GasCylienderID AS [AllNewsID]





GO
/****** Object:  StoredProcedure [dbo].[InsertGuidelinedetailAndAllFreatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertGuidelinedetailAndAllFreatureChildXML]
(	
	@GuidelinedetailXML ntext 
) 

AS
  DECLARE @docHandle int, @GuideLineDetailID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @GuidelinedetailXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[GuideLineDetail]
  (
	   [GuideLineID]
      ,[Title]
      ,[Description]
	  ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      --,[ModifiedBy]
      --,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT 
		GuideLineID
		,Title
		,Description
		,ImageUrl
      ,CreatedBy
      ,CreatedDate
      --,ModifiedBy
      --,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/GuideLineDetail', 3) WITH ( 
	GuideLineID int
	,Title nvarchar(500)
	,Description ntext
	,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      --,ModifiedBy bigint
      --,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @GuideLineDetailID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[GuideLineDetailMore](
   [GuideLineDetailID]
   ,[Title]
      ,[Description]
	   ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      --,[ModifiedBy]
      --,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT 
   @GuideLineDetailID
    ,Title
		  ,Description
		  ,ImageUrl
      ,CreatedBy
      ,CreatedDate

      --,ModifiedBy
      --,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/GuideLineDetail/GuideLineDetailMoreColl/GuideLineDetailMore', 3)   WITH 
   (
    GuideLineDetailID int
	,Title nvarchar(500)
	,Description ntext
	,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      --,ModifiedBy bigint
      --,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @GuideLineDetailID AS [GuideLineDetailID]





GO
/****** Object:  StoredProcedure [dbo].[InsertGuideLineDetailChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertGuideLineDetailChildXML]
(	
	@GuideLineXML ntext 
) 

AS
  DECLARE @docHandle int, @GuideLineID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @GuideLineXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[GuideLine]
  (
	   [BusinessTypeID]
      ,[Title]
      ,[Description]
      ,[ImageUrl]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT 
	   BusinessTypeID
      ,Title
      ,Description
      ,ImageUrl
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/GuideLine', 3) WITH ( 
	  BusinessTypeID int
	  ,Title nvarchar(500)
	  ,Description ntext
      ,ImageUrl nvarchar(999)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @GuideLineID = SCOPE_IDENTITY()
   ---Picture 
   INSERT INTO [dbo].[GuideLineDetail](
       [GuideLineID]
      ,[Title]
	  ,[ImageUrl]
      ,[Description]
	  ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @GuideLineID
      ,Title
	  ,ImageUrl
      ,Description
	  
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/GuideLine/GuideLineDetailColl/GuideLineDetail', 3)   WITH 
   (
       GuideLineID int
      ,Title nvarchar(500)
      ,ImageUrl nvarchar(999)
	  ,Description ntext
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @GuideLineID AS [GuideLineID]





GO
/****** Object:  StoredProcedure [dbo].[InsertLISchemaFreatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLISchemaFreatureChildXML]
(	
	@LISchemaFreatureXML ntext
) 

AS
  DECLARE @docHandle int, @LISchemaID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @LISchemaFreatureXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[LISchema]
  (
	   [NumberOfYear]
      ,[AgeMin]
      ,[AgeMax]
      ,[UnitAmount]
      ,[MultiplyFactor]
      ,[UnitPremiumAmount]
      ,[UnitReturnAmount]
      ,[PremiumPolicyID]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]
 )
 
  SELECT  NumberOfYear
      ,AgeMin
      ,AgeMax
      ,UnitAmount
      ,MultiplyFactor
      ,UnitPremiumAmount
      ,UnitReturnAmount
      ,PremiumPolicyID
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
  FROM Openxml( @docHandle, '/LISchema', 3) WITH ( 
		NumberOfYear int
      ,AgeMin int
      ,AgeMax int
      ,UnitAmount money
      ,MultiplyFactor int
      ,UnitPremiumAmount money
      ,UnitReturnAmount money
      ,PremiumPolicyID int
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @LISchemaID = SCOPE_IDENTITY()
   ---Picture
   INSERT INTO [dbo].[LIApplicableFeature](
   [LISchemaID]
      ,[Description]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @LISchemaID AS LISchemaID,
   Description
      ,CreatedBy
      ,CreatedDate

      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/LISchema/LIApplicableFeatureColl/LIApplicableFeature', 3)   WITH 
   (
    LISchemaID int
	,Description nvarchar(500)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @LISchemaID AS [LISchemaID]





GO
/****** Object:  StoredProcedure [dbo].[InsertLoanInfoFeatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLoanInfoFeatureChildXML]
(	
	@LoanInfoXML ntext 
) 

AS
  DECLARE @docHandle int, @LoanInfoID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @LoanInfoXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[LoanInfo]
  (
		[CompanyInfoID],
		[LoanTypeID],
		[LoanAmtYearScheduleID],
		[Description],
		[TotalAmount],
		[TotalInstallmentNo],
		[MonthlyReturnAmount],
		[TotalReturnAmount],
		[PostAdDate],
		[PostLastDisplayDate],
		[PaymentAmt],
		[IsVerified],
		[VerifiedBy],
		[RedirectUrl],
		[TotalVisitor],
		[IsPostAdExtended],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[IsRemoved]
 )
 
  SELECT 
	   [CompanyInfoID],
		[LoanTypeID],
		[LoanAmtYearScheduleID],
		[Description],
		[TotalAmount],
		[TotalInstallmentNo],
		[MonthlyReturnAmount],
		[TotalReturnAmount],
		[PostAdDate],
		[PostLastDisplayDate],
		[PaymentAmt],
		[IsVerified],
		[VerifiedBy],
		[RedirectUrl],
		[TotalVisitor],
		[IsPostAdExtended],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[IsRemoved]
  FROM Openxml( @docHandle, '/LoanInfo', 3) WITH ( 
	  CompanyInfoID int
	  ,LoanTypeID int
	  ,LoanAmtYearScheduleID int
      ,[Description] nvarchar(500)
      ,TotalAmount money
      ,TotalInstallmentNo int
	  ,MonthlyReturnAmount money
	  ,TotalReturnAmount money
	  ,PostAdDate datetime
	  ,PostLastDisplayDate datetime
	  ,PaymentAmt money
	  ,IsVerified bit
	  ,VerifiedBy bigint
	  ,RedirectUrl nvarchar(2000)
	  ,TotalVisitor int
	  ,IsPostAdExtended bit
	  ,CreatedBy bigint
	  ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @LoanInfoID = SCOPE_IDENTITY()
   ---Picture 
   INSERT INTO [dbo].[LoanFeature](
       [LoanInfoID]
      ,[Description]
	  ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @LoanInfoID
	  ,[Description]
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/LoanInfo/LoanFeatureColl/LoanFeature', 3)   WITH 
   (
       LoanInfoID bigint
      ,[Description] nvarchar(500)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @LoanInfoID AS [LoanInfoID]





GO
/****** Object:  StoredProcedure [dbo].[InsertMobilePhoneInfoAndFeatureChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC InsertMobilePhoneInfoAndFeatureChildXML 3

	*/
	CREATE PROCEDURE [dbo].[InsertMobilePhoneInfoAndFeatureChildXML]
	(	
	@MobilePhoneInfoXML ntext 
	) 

	AS
	DECLARE @docHandle int, @MobilePhoneInfoID int
	EXEC sp_xml_preparedocument @docHandle OUTPUT, @MobilePhoneInfoXML
  
	BEGIN TRANSACTION--------------
  
	INSERT INTO [dbo].[MobilePhoneInfo]
	(
			[CompanyInfoID], 
			[NetworkProviderID], 
			[MPTypeID], 
			[SIMAvailableID], 
			[ModelName], 
			[TotalTalkTime], 
			[TalkTimeUnitID], 
			[TotalTextMessage], 
			[TotalUsableData], 
			[UsableDataUnitID],
			[ConnectionTypeID], 
			[TotalPrice], 
			[ContractDuration], 
			[MonthlyInstallmentAmt], 
			[WarrantyInfo], 
			[PictureUrl], 
			[PostAdDate], 
			[PostLastDisplayDate], 
			[IsVerified], 
			[VerifiedBy], 
			[RedirectUrl],
			[CreatedBy], 
			[CreatedDate], 
			[ModifiedBy], 
			[ModifiedDate],
			[IsRemoved]
	)
 
	SELECT  CompanyInfoID, NetworkProviderID, MPTypeID,  SIMAvailableID, ModelName, TotalTalkTime, TalkTimeUnitID, 
			TotalTextMessage, TotalUsableData, UsableDataUnitID, ConnectionTypeID,  TotalPrice, ContractDuration,
			MonthlyInstallmentAmt, WarrantyInfo,PictureUrl, PostAdDate, PostLastDisplayDate, IsVerified, VerifiedBy, 
			RedirectUrl, CreatedBy,CreatedDate, ModifiedBy, ModifiedDate,IsRemoved
	FROM Openxml( @docHandle, '/MobilePhoneInfo', 3) WITH ( CompanyInfoID int, 

		NetworkProviderID int , 

		MPTypeID int  , 

		SIMAvailableID int , 

		ModelName nvarchar(200) , 

		TotalTalkTime int , 

		TalkTimeUnitID int  , 

		TotalTextMessage int , 

		TotalUsableData decimal(10, 2) , 

		UsableDataUnitID int,

		ConnectionTypeID int  , 

		TotalPrice money , 

		ContractDuration int , 

		MonthlyInstallmentAmt money , 

		WarrantyInfo nvarchar(200) ,

		PictureUrl nvarchar(2000) , 

		PostAdDate datetime , 

		PostLastDisplayDate datetime , 

		IsVerified bit,

		VerifiedBy bigint,

		RedirectUrl nvarchar(2000),

		CreatedBy bigint , 

		CreatedDate datetime , 

		ModifiedBy bigint , 

		ModifiedDate datetime,

		IsRemoved bit)
  
	IF @@ERROR<>0 
	BEGIN 
		ROLLBACK TRANSACTION RETURN -100 
	END
	SET @MobilePhoneInfoID = SCOPE_IDENTITY()
	---MPFeature
	INSERT INTO [dbo].[MPFeature]
			([MobilePhoneID],
			[Description],
			[CreatedBy], 
			[CreatedDate], 
			[ModifiedBy], 
			[ModifiedDate],
			[IsRemoved]) 
	SELECT @MobilePhoneInfoID AS MobilePhoneInfoID, Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsRemoved
	FROM OpenXml( @docHandle, '/MobilePhoneInfo/MPFeatureColl/MPFeature', 3)   WITH (Description nvarchar(500),CreatedBy bigint , 

		CreatedDate datetime , 

		ModifiedBy bigint , 

		ModifiedDate datetime,

		IsRemoved bit ) 
   
	IF @@ERROR<>0 
		BEGIN 
		ROLLBACK TRANSACTION RETURN -101 
		END	 
     
		IF @@ERROR<>0 
		BEGIN 
		ROLLBACK TRANSACTION RETURN -103 
		END
	COMMIT TRANSACTION------------------------------

	EXEC sp_xml_removedocument @docHandle SELECT @MobilePhoneInfoID AS [MobilePhoneInfo]





GO
/****** Object:  StoredProcedure [dbo].[InsertMortgageDetailChildXML]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertMortgageDetailChildXML]
(	
	@MortgageXML ntext 
) 

AS
  DECLARE @docHandle int, @MortgageID int
  EXEC sp_xml_preparedocument @docHandle OUTPUT, @MortgageXML
  
  BEGIN TRANSACTION--------------
  
  INSERT INTO [dbo].[Mortgage]
  (
		[CompanyInfoID],
		[OperationTypeID],
		[TypeID],
		[APR],
		[TermYearID],
		[PaymentTypeID],
		[FeeOrCharge],
		[Description],
		[LTV],
		[PropertyValueMinAmt],
		[PropertyValueMaxAmt],
		[MonthlyInstallmentAmt],
		[IsPostAdExtended],
		[PostAdDate],
		[PostLastDisplayDate],
		[PaymentAmt],
		[IsVerified],
		[RedirectUrl],
		[TotalVisitor],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[IsRemoved]
 )
 
  SELECT 
	   [CompanyInfoID],
		[OperationTypeID],
		[TypeID],
		[APR],
		[TermYearID],
		[PaymentTypeID],
		[FeeOrCharge],
		[Description],
		[LTV],
		[PropertyValueMinAmt],
		[PropertyValueMaxAmt],
		[MonthlyInstallmentAmt],
		[IsPostAdExtended],
		[PostAdDate],
		[PostLastDisplayDate],
		[PaymentAmt],
		[IsVerified],
		[RedirectUrl],
		[TotalVisitor],
		[CreatedBy],
		[CreatedDate],
		[ModifiedBy],
		[ModifiedDate],
		[IsRemoved]
  FROM Openxml( @docHandle, '/Mortgage', 3) WITH ( 
	  CompanyInfoID int
	  ,OperationTypeID int
	  ,TypeID int
      ,APR float
      ,TermYearID int
      ,PaymentTypeID int
	  ,FeeOrCharge money
	  ,[description] nvarchar(500)
	  ,LTV float
	  ,PropertyValueMinAmt money
	  ,PropertyValueMaxAmt money
	  ,MonthlyInstallmentAmt money
	  ,IsPostAdExtended bit
	  ,PostAdDate datetime
	  ,PostLastDisplayDate datetime
	  ,PaymentAmt money
	  ,IsVerified bit
	  ,VerifiedBy bigint
	  ,RedirectUrl nvarchar(2000)
	  ,TotalVisitor int
	  ,CreatedBy bigint
	  ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit)
  
  IF @@ERROR<>0 
    BEGIN 
       ROLLBACK TRANSACTION RETURN -100 
    END
   SET @MortgageID = SCOPE_IDENTITY()
   ---Picture 
   INSERT INTO [dbo].[MortgageInterestRate](
       [MortgageID]
      ,[UptoYear]
	  ,[InterestRateTypeID]
      ,[Rate]
	  ,[Note]
	  ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifiedBy]
      ,[ModifiedDate]
      ,[IsRemoved]) 
   SELECT @MortgageID
      ,UptoYear
	  ,InterestRateTypeID
      ,Rate
	  ,Note
      ,CreatedBy
      ,CreatedDate
      ,ModifiedBy
      ,ModifiedDate
      ,IsRemoved
   FROM OpenXml( @docHandle, '/Mortgage/MortgageInterestRateColl/MortgageInterestRate', 3)   WITH 
   (
       MortgageID bigint
      ,UptoYear int
      ,InterestRateTypeID int
	  ,Rate float
	  ,Note nvarchar(200)
      ,CreatedBy bigint
      ,CreatedDate datetime
      ,ModifiedBy bigint
      ,ModifiedDate datetime
      ,IsRemoved bit	
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

EXEC sp_xml_removedocument @docHandle SELECT @MortgageID AS [MortgageID]





GO
/****** Object:  StoredProcedure [dbo].[Sp_GetAllBroadBandInternetByTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <13 April 2015 > 
-- For Retriving All BDInternet  <BroadbandMobileDeals Page>
/*===============================================*/
CREATE PROC [dbo].[Sp_GetAllBroadBandInternetByTypeID]
(
	@TypeID int,
	@startRowNumber int,
	@maxRowNumber int
)
As
/*===============================================*/
BEGIN TRY 

	Set @maxRowNumber = @startRowNumber+ @maxRowNumber
	--Exec Sp_GetAllBroadBandInternetByTypeID 2, 0,10
-- Retrieve column specific information 
BEGIN
	SELECT F.RowNumber,
	F.REDIRECTURL,
	F.PROVIDER,
	F.OFFER,
	F.PACKAGE,
	F.USAGE,
	F.SPEED,
	F.[CONTRACT],
	F.PAYMENT,
	F.PAYMENTSCHEDULE 
	FROM
		(SELECT ROW_NUMBER() OVER(ORDER BY BDI.IID) AS RowNumber,
				ISNULL(BDI.RedirectUrl,'')AS REDIRECTURL,
				ISNULL (C.LogoUrl,'') AS PROVIDER, 
				ISNULL (BDI.PackageImageUrl,'') AS OFFER,
				ISNULL (BDI.PackageName,'') AS PACKAGE, 
				ISNULL (BDI.DataAmount,'') AS USAGE,
				CONVERT(Varchar(50), BDI.NetSpeed) + (CASE BDI.NetSpeedUnitID WHEN 1 THEN 'KB' WHEN 2 THEN 'MB' WHEN 3 THEN 'GB' END) AS SPEED,		 
				ISNULL( CONVERT (varchar(50), BDI.ContractDuration)+ (CASE BDI.ContractTypeID WHEN 1 THEN ' Month' WHEN 2 THEN ' Quatar' WHEN 3 THEN ' Half Year' WHEN 4 THEN ' Year' END),'') AS [CONTRACT],
				'TK '+CONVERT(varchar(50), BDI.ChargeAmount) AS PAYMENT,
				(SELECT CASE BDI.ChargeTypeID WHEN 1 THEN 'Per Month' WHEN 2 THEN 'Per Quatar' WHEN 3 THEN 'Per Half Year' WHEN 4 THEN 'Per Year' END ) AS PAYMENTSCHEDULE
		FROM BDInternet BDI
		JOIN CompanyInfo C ON BDI.ProviderID=C.IID
		WHERE BDI.IsRemoved=0 AND BDI.TypeID=@TypeID
		)F
	WHERE  F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
	ORDER BY F.USAGE DESC

END


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
/****** Object:  StoredProcedure [dbo].[SP_GetAllCardTypeForBankingNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllCardTypeForBankingNews 3

	*/
	create PROCEDURE [dbo].[SP_GetAllCardTypeForBankingNews]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select card.IID, 
	   
		card.CardTypeID as CardType
		
	from CardInfo card		
	where
	card.IsRemoved='false'
	
    
	END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllCardTypeForBankingNews 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllFeature]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	SELECT  
	a.IID,
	a.BusinessTypeID,
	a.BusinessTypeBreakdownID,
	a.TitleName,
	SUBSTRING(ISNULL(a.[Description],''),0,100) AS "Description",
	a.ImageUrl,
	a.IsRemoved,
	a.CreatedBy,
	a.CreatedDate,
	a.ModifiedBy,
	a.ModifiedDate
	FROM    (SELECT *,
					ROW_NUMBER() OVER (PARTITION BY BusinessTypeID ORDER BY IID) AS RowNumber
			 FROM   AllFeature
			 ) AS a
	WHERE   a.RowNumber = 1 AND a.IsRemoved=0
	
    
	END
--EXEC SP_GetAllFeature

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFeatureByBussinessTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC [SP_GetAllFeatureByBussinessTypeID] 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllFeatureByBussinessTypeID]
	(
	@BussinessTypeID int
	)
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	SELECT  
	a.IID,
	a.TitleName,
	a.BusinessTypeID,
	a.BusinessTypeBreakdownID,
	ISNULL(a.Description,'') AS "Description",
	a.CreatedBy,
	a.CreatedBy,
	a.ModifiedDate,
	a.ModifiedDate,
	a.IsRemoved,
	a.ImageUrl
	FROM    AllFeature a
	WHERE   a.BusinessTypeID = @BussinessTypeID AND a.IsRemoved=0 AND a.BusinessTypeBreakdownID != 0
	
    
	END

	--exec SP_GetAllFeatureByBussinessTypeID 1

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFeatureDetails]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC [[SP_GetAllFeatureDetails]] 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllFeatureDetails]
	(
	@BussinessBrID int
	)
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select 
	a.IID,
	a.BusinessTypeID,
	a.BusinessTypeBreakdownID,
	a.TitleName,
	SUBSTRING(ISNULL(a.[Description],''),0,99) AS "Description",
	a.ImageUrl,
	a.IsRemoved,
	a.CreatedBy,
	a.CreatedDate,
	a.ModifiedBy,
	a.ModifiedDate 
	from AllFeature a
	where a.BusinessTypeID =@BussinessBrID AND a.IsRemoved=0
	
	    
	END
--EXEC SP_GetAllFeatureDetails

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFeatureDetailsByFeatureID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllCardTypeForBankingNews 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllFeatureDetailsByFeatureID]
	(
	@FeatureID int
	)
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	SELECT 
	a.IID,
	a.AllFeatureID,
	a.TitleName,
	SUBSTRING(ISNULL(a.[Description],''),0,100) AS "Description",
	a.ImageUrl,
	a.IsRemoved,
	a.CreatedBy,
	a.CreatedDate,
	a.ModifiedBy,
	a.ModifiedDate
	FROM    AllFeatureDetail a
	WHERE   a.AllFeatureID = @FeatureID AND a.IsRemoved=0
	END

	--exec SP_GetAllFeatureDetailsByFeatureID 1

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFeatureMoreDetails]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllCardTypeForBankingNews 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllFeatureMoreDetails]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select DISTINCT(BusinessTypeID) from dbo.AllFeature 
	    
	END
--EXEC SP_GetAllFeatureMoreDetails

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllLiSchemaNoOfYearForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllLiSchemaNoOfYearForListView]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	select 
	LS.NumberOfYear as DiplayMember,
	LS.NumberOfYear as Value
	from
	LISchema LS
	where LS.IsRemoved='false'	
	order by LS.NumberOfYear
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllLocationForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllLocationForListView]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	select LOC.IID, loc.CurrentLocation, CT.Name as Country, DST.Name as District, PO.Name as PostOffice, PS.Name as PoliceStation from Location LOC
	inner join Country CT on LOC.CountryID=CT.IID
	inner join District DST on LOC.DistrictID=DST.IID
	inner join PoliceStation PS on LOC.PoliceStationID=PS.IID
	left join PostOffice PO on LOC.PostOfficeID=po.IID

	order by LOC.IID
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMobileInfoForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllMobileInfoForListView 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllMobileInfoForListView]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select mobile.IID, 

	    comInfo.Name as CompanyName,
	    mpType.TypeName as MPTypeName,
		mobile.ModelName as ModelName,
	 	mobile.TotalTextMessage as TotalTextMessage,
		mobile.TotalUsableData as TotalUsableData,
        mobile.TotalTalkTime as TotalTalkTime,                                
		mobile.TotalPrice  as TotalPrice,
		mobile.ContractDuration  as ContractDuration,
		mobile.MonthlyInstallmentAmt  as MonthlyInstallmentAmt,
		mobile.WarrantyInfo as WarrantyInfo,
		mobile.PictureUrl as PictureUrl,
		mobile.PostAdDate as PostAdDate,
		mobile.PostLastDisplayDate as PostLastDisplayDate,
		mobile.RedirectUrl as RedirectUrl,

		mobile.ConnectionTypeID as ConnectionType,
		mobile.NetworkProviderID as NetworkServiceProvider,
		mobile.TalkTimeUnitID as TalkTimeUnit,
        mobile.UsableDataUnitID as UsableDataUnit,
		mobile.SIMAvailableID as SIMAvailable

	from MobilePhoneInfo mobile
	
	inner join CompanyInfo comInfo on mobile.CompanyInfoID=COMINFO.IID
	inner join MPType mpType on mobile.MPTypeID= mpType.IID

	where
	mobile.IsRemoved='false'
	
    
	END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMorgagesCount]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   SP_GetFourMortgageType


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetAllMorgagesCount]
(
	@mortgageTypeID int,
	@paymentTypeID int,
	@rateTypeID int,
	@periodID int
)
As

BEGIN  

	SELECT m.CompanyInfoID,ROW_NUMBER() Over(ORDER BY m.[APR] ) ROWNUMBER,
		m.IID,
		m.[TypeID],
		m.[APR],
		m.[FeeOrCharge],
		m.MonthlyInstallmentAmt,
		c.[LogoUrl],
		m.[RedirectUrl],
		m.[Description],
		m.[PaymentTypeID]
	FROM dbo.[Mortgage] AS m
	LEFT JOIN dbo.CompanyInfo AS c on m.CompanyInfoID = c.IID

	where m.IID in(select MortgageID from MortgageInterestRate 
					where (CASE WHEN @periodID=-1 THEN -1 ELSE  MortgageInterestRate.UptoYear END) =@periodID 
					AND (CASE WHEN @rateTypeID=-1 THEN -1 ELSE  MortgageInterestRate.InterestRateTypeID END) =@rateTypeID 
					AND MortgageInterestRate.IsRemoved=0)
	AND (CASE WHEN @paymentTypeID=-1 THEN -1 ELSE m.PaymentTypeID END)=@paymentTypeID
	AND (CASE WHEN @mortgageTypeID =-1 THEN -1 ELSE m.TypeID END)=@mortgageTypeID
	AND m.IsRemoved =0
	
END 
--exec SP_GetAllMorgagesCount -1,-1,-1,-1

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMorgageWithInterestRate]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   SP_GetAllMorgageWithInterestRate 0, 10, 1,-1,-1,4


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetAllMorgageWithInterestRate]
(
	@startRowNumber int,
	@maxRowNumber int,
	@mortgageTypeID int,
	@paymentTypeID int,
	@rateTypeID int,
	@periodID int	
)
As

BEGIN TRY 
Set @maxRowNumber = @startRowNumber+ @maxRowNumber

BEGIN
Select F.IID,F.ROWNUMBER,F.LogoUrl,F.TypeID,F.APR,F.FeeOrCharge ,F.MonthlyInstallmentAmt,F.RedirectUrl,F.[Description],F.[PaymentTypeID] from
	(SELECT m.CompanyInfoID,ROW_NUMBER() Over(ORDER BY m.[APR] ) ROWNUMBER,
		m.IID,
		m.[TypeID],
		m.[APR],
		m.[FeeOrCharge],
		m.MonthlyInstallmentAmt,
		c.[LogoUrl],
		m.[RedirectUrl],
		m.[Description],
		m.[PaymentTypeID]
	FROM dbo.[Mortgage] AS m
	LEFT JOIN dbo.CompanyInfo AS c on m.CompanyInfoID = c.IID

	where m.IID in(select MortgageID from MortgageInterestRate 
					where (CASE WHEN @periodID=-1 THEN -1 ELSE  MortgageInterestRate.UptoYear END) =@periodID 
					AND (CASE WHEN @rateTypeID=-1 THEN -1 ELSE  MortgageInterestRate.InterestRateTypeID END) =@rateTypeID 
					AND MortgageInterestRate.IsRemoved=0)
	AND (CASE WHEN @paymentTypeID=-1 THEN -1 ELSE m.PaymentTypeID END)=@paymentTypeID
	AND (CASE WHEN @mortgageTypeID =-1 THEN -1 ELSE m.TypeID END)=@mortgageTypeID
	AND m.IsRemoved =0
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
/****** Object:  StoredProcedure [dbo].[SP_GetAllMortgageForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllMortgageForListView]
	
AS
BEGIN
	
	SET NOCOUNT ON;	

	select MORT.IID, 

	COMINFO.Name as CompanyName,

	MORT.TypeID as MortageType,
	MORT.APR,

	MOTY.NumberOfYear as MortgageTermYear,

	MORT.PaymentTypeID as PaymentType,
	MORT.FeeOrCharge,
	MORT.PostAdDate,
	MORT.PostLastDisplayDate,
	MORT.RedirectUrl
	 

	from Mortgage MORT
	
	inner join CompanyInfo COMINFO on MORT.CompanyInfoID=COMINFO.IID
	left join MortgageTermYear MOTY  on MORT.TermYearID=MOTY.IID

	where
	MORT.IsRemoved='false'
	
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMortgageProvider]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   SP_GetFourMortgageType


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetAllMortgageProvider]
As

BEGIN  
--///Create temp table
DECLARE  @tempTable  TABLE
(
	companyID int,
	LogoUrl nvarchar(250),
	ProviderUrl varchar(255),
	IsRemoved bit
)
	INSERT INTO @tempTable
	SELECT DISTINCT(com.IID), com.LogoUrl,mort.RedirectUrl, com.IsRemoved
	from [dbo].[Mortgage] AS mort
	LEFT JOIN [dbo].[CompanyInfo] AS com on mort.CompanyInfoID = com.IID
	where com.IsRemoved = 0
	--ORDER BY com.IID,CHECKSUM(NEWID())

	SELECT top 6 companyID, LogoUrl,ProviderUrl FROM @tempTable
	ORDER BY companyID ,CHECKSUM(NEWID())
END 



--exec SP_GetAllMortgageProvider

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllNewsCommunityType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllNewsCommunityType 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetAllNewsCommunityType]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select distinct news.NewsTypeID,
		news.NewsType as NewsType
		
	from CommunityNews news		
	where
	news.IsRemoved='false'
	
    
	END


GO
/****** Object:  StoredProcedure [dbo].[Sp_GetAllNewsListByBusinessTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <29 April 2015 > 
-- Modify date: <07 May 2005>
-- For Retriving All News For businesstypeID <AllNews Page>

CREATE PROC [dbo].[Sp_GetAllNewsListByBusinessTypeID]
(
	@BusinessTypeID int=1

)
As

BEGIN TRY 
-- Exec Sp_GetAllNewsListByBusinessTypeID 1
-- Retrieve column specific information 
BEGIN
	SELECT  a.IID, 
	CONVERT(nvarchar, a.IID) as Name, 
	a.BusinessTypeID,
	a.BusinessTypeBreakdownID
	FROM
	(
	SELECT *,
					Rank() OVER (PARTITION BY BusinessTypeBreakdownID ORDER BY IID) AS Rank
			 FROM   AllNews where IsRemoved=0  and BusinessTypeID=@BusinessTypeID
	 ) AS a
	WHERE   Rank = 1

END		


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
/****** Object:  StoredProcedure [dbo].[SP_GetAllPostOfficeForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllPostOfficeForListView]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	select PO.IID,PO.Code,  CT.Name as Country,DOS.Name as DivisionOrState, DST.Name as District, PS.Name as PoliceStation, PO.Name as PostOffice from PostOffice PO
	inner join Country CT on PO.CountryID=CT.IID
	inner join District DST on PO.DistrictID=DST.IID
	inner join DivisionOrState DOS on PO.DistrictID=DOS.IID
	left join PoliceStation PS on PO.PoliceStationID=PS.IID

	where PO.IsRemoved='false'
	
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllRandomGuideLineRowsByBusenessTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <05 May 2015 >
-- For Retriving All Guide By BusinessTypeID <InsuranceDefault Page>

CREATE PROC [dbo].[SP_GetAllRandomGuideLineRowsByBusenessTypeID]
(
	@BusinessTypeID int

)
As

BEGIN TRY 
-- exec SP_GetAllRandomGuideLineRowsByBusenessTypeID 4
		
-- Retrieve column specific information 

SELECT  top 4 IID,
			IID as Name,
			BusinessTypeID,
            ISNULL (Title,' ')AS Title , 
            ISNULL (SUBSTRING ([Description],1,35),'...')+'...' AS [Description], 
            ImageUrl
            FROM [GuideLine]
            WHERE BusinessTypeID=@BusinessTypeID AND IsRemoved=0 ORDER BY newid()

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
/****** Object:  StoredProcedure [dbo].[SP_GetAllUpToYear]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllUpToYear]
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT Distinct(CONVERT(varchar(50), dbo.MortgageInterestRate.UptoYear)) + ' Years' as "InitialPeriod", dbo.MortgageInterestRate.UptoYear 
	FROM dbo.MortgageInterestRate 
	WHERE dbo.MortgageInterestRate.IsRemoved=0
	ORDER BY UptoYear ASC
END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetDataForLifeInsuranceQuotesSearchReasultDisplay]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

exec [SP_GetDataForLifeInsuranceQuotesSearchReasultDisplay]

 @CriticalIllnessCoverAmount=-1,
 @coverAmount=120,
 @noOfYear=4


*/
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetDataForLifeInsuranceQuotesSearchReasultDisplay]
( 
 @CriticalIllnessCoverAmount money,
 @coverAmount money,
 @noOfYear int
)
AS
BEGIN
	
	SET NOCOUNT ON	
	if @CriticalIllnessCoverAmount=0
	begin
	select LI.IID
	,LI.CriticalillnessCoverAmount
	,LI.TotalCoverAmount
	,LI.ClaimsPaidPercent
	, LI.PackageName
	,LI.IsGuranteedPremium	
	,ComInfo.LogoUrl
	,LiScma.PremiumPolicyID
	,LiScma.UnitPremiumAmount
	,LiScma.NumberOfYear as PolicyTerm
	,ComInfo.WebAddress
	from LifeInsurance LI 
	inner join CompanyInfo ComInfo on LI.CompanyInfoID=ComInfo.IID
	inner join LISchema LiScma on LI.LISchemaID=LiScma.IID
	where 
	LI.IsRemoved='false'	
	and LI.CriticalillnessCoverAmount=0.00
	and LI.TotalCoverAmount=@coverAmount 
	and LiScma.NumberOfYear=@noOfYear
	end

	else if @CriticalIllnessCoverAmount=-1
	begin
	select LI.IID
	,LI.CriticalillnessCoverAmount
	,LI.TotalCoverAmount
	,LI.ClaimsPaidPercent
	, LI.PackageName
	,LI.IsGuranteedPremium	
	,ComInfo.LogoUrl
	,LiScma.PremiumPolicyID
	,LiScma.UnitPremiumAmount
	,LiScma.NumberOfYear as PolicyTerm
	,ComInfo.WebAddress
	from LifeInsurance LI 
	inner join CompanyInfo ComInfo on LI.CompanyInfoID=ComInfo.IID
	inner join LISchema LiScma on LI.LISchemaID=LiScma.IID
	where 
	LI.IsRemoved='false'	
	and LI.CriticalillnessCoverAmount!=0.00
	and LI.TotalCoverAmount=@coverAmount 
	and LiScma.NumberOfYear=@noOfYear
	end

	else
	begin
	select LI.IID
	,LI.CriticalillnessCoverAmount
	,LI.TotalCoverAmount
	,LI.ClaimsPaidPercent
	,LI.PackageName
	,LI.IsGuranteedPremium	
	,ComInfo.LogoUrl
	,LiScma.PremiumPolicyID
	,LiScma.UnitPremiumAmount
	,LiScma.NumberOfYear as PolicyTerm
	,ComInfo.WebAddress
	from LifeInsurance LI 
	inner join CompanyInfo ComInfo on LI.CompanyInfoID=ComInfo.IID
	inner join LISchema LiScma on LI.LISchemaID=LiScma.IID
	where 
	LI.IsRemoved='false'
	and LI.CriticalillnessCoverAmount=@CriticalIllnessCoverAmount
	and LI.TotalCoverAmount=@coverAmount 
	and LiScma.NumberOfYear=@noOfYear
	end
	
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetDealerForListViewByCompanyIid]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Mahbub>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
/*
exec [SP_GetDealerForListViewByCompanyIid]
@companyIid=13
*/

CREATE PROCEDURE [dbo].[SP_GetDealerForListViewByCompanyIid]
	(
	@companyIid int
	)
AS
BEGIN
	
	SET NOCOUNT ON;	

	select
	GD.IID,
	GD.TradeName,
	GD.DealerName,
	DS.Name as District
	from GasDealerInfo GD
	inner join District DS on GD.DistrictID=DS.IID
	
	where
	GD.IsRemoved='false' and GD.CompanyInfoID=@companyIid
    
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GetFourMortgageType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   SP_GetFourMortgageType


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetFourMortgageType]
As

BEGIN TRY 


	SELECT top 4 
	mt.IID,
	SUBSTRING(ISNULL(mt.Name,''),0,9) AS "Name",
	SUBSTRING(ISNULL(mt.[Description],''),0,40) AS "Description" ,
	mt.ImageUrl
	from [dbo].[MortgageTypeInfo] AS mt
	
	ORDER BY mt.Name,CHECKSUM(NEWID())

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
/****** Object:  StoredProcedure [dbo].[SP_GetLastIIDofBDInternet]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <21 May 2015 >

CREATE PROC [dbo].[SP_GetLastIIDofBDInternet]

As

BEGIN TRY 

-- Retrieve column specific information 
SELECT TOP 1 IID FROM BDInternet WHERE IsRemoved=0 ORDER BY IID DESC


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
/****** Object:  StoredProcedure [dbo].[SP_GetRandomAllNewsRowsByBusenessTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <05 May 2015 >
-- For Retriving All News By BusinessTypeID <InsuranceDefault Page>

CREATE PROC [dbo].[SP_GetRandomAllNewsRowsByBusenessTypeID]
(
	@BusinessTypeID int

)
As

BEGIN TRY 

		
-- Retrieve column specific information 

SELECT  top 4 IID,
			Convert (nvarchar,IID) as Name,
			BusinessTypeID,
            ISNULL (TitleName,' ')AS TitleName ,
			BusinessTypeBreakdownID, 
            ISNULL (SUBSTRING ([Description],1,35),'...')+'...' AS [Description], 
            ImageUrl
            FROM [AllNews]
            WHERE BusinessTypeID=@BusinessTypeID AND IsRemoved=0 ORDER BY newid()

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
/****** Object:  StoredProcedure [dbo].[SP_GetRecentlySaved]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   [SP_GetRecentlySaved]


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetRecentlySaved]
As

BEGIN  
	
	SELECT  TOP 1 
	com.Name,
	com.LogoUrl,
	mort.[OperationTypeID],
	mort.[TypeID],
	mort.[APR],
	mort.[PaymentTypeID],
	mort.[FeeOrCharge],
	mort.[Description],
	mort.[LTV],
	mort.[PropertyValueMinAmt],
	mort.[PropertyValueMaxAmt],
	mort.[MonthlyInstallmentAmt],
	mort.[IsPostAdExtended],
	mort.[PostAdDate],
	mort.[PostLastDisplayDate],
	mort.[PaymentAmt],
	mort.[IsVerified],
	mort.[VerifiedBy],
	mort.[RedirectUrl],
	mort.[CreatedBy],
	mort.[CreatedDate],
	mort.[ModifiedBy],
	mort.[ModifiedDate],
	mort.[IsRemoved]
	from [dbo].[Mortgage] AS mort
	LEFT JOIN [dbo].[CompanyInfo] AS com on mort.CompanyInfoID = com.IID
	ORDER BY mort.IID DESC
	
END 



--exec SP_GetAllMortgageProvider

GO
/****** Object:  StoredProcedure [dbo].[SP_GetTop2HelpAdvice]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*===================================================================================


	EXEC   [SP_GetTop2HelpAdvice]


=====================================================================================*/


CREATE PROCEDURE [dbo].[SP_GetTop2HelpAdvice]
As

BEGIN  
	SELECT top 2 
	h.IID,
	h.Title,
	SUBSTRING(ISNULL(h.[Description],''),0,100) AS "Description",
	h.[Image],
	h.CreatedBy,
	h.CreatedDate,
	h.ModifiedBy,
	h.ModifiedDate,
	h.IsRemoved
	from HelpAdvice AS h
	where h.IsRemoved=0
	ORDER BY h.IID,CHECKSUM(NEWID())
END 



--exec SP_GetAllMortgageProvider

GO
/****** Object:  StoredProcedure [dbo].[SP_GetTopFourFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_GetAllCardTypeForBankingNews 3

	*/
	CREATE PROCEDURE [dbo].[SP_GetTopFourFeature]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	SELECT  top 4 
	a.IID,
	a.BusinessTypeID,
	a.BusinessTypeBreakdownID,
	a.TitleName,
	SUBSTRING(ISNULL(a.[Description],''),0,25) AS "Description",
	a.ImageUrl,
	a.IsRemoved,
	a.CreatedBy,
	a.CreatedDate,
	a.ModifiedBy,
	a.ModifiedDate,
	CONVERT(nvarchar,a.BusinessTypeID) "BussinessTypeName",CONVERT(nvarchar,a.BusinessTypeBreakdownID) "BussinessTypeBrName"
	FROM    (SELECT *,
					ROW_NUMBER() OVER (PARTITION BY BusinessTypeID ORDER BY IID) AS RowNumber
			 FROM   AllFeature
			 Where IsRemoved=0
			 ) AS a
	WHERE   a.RowNumber = 1
	ORDER BY IID ,CHECKSUM(NEWID())
    
	END
--EXEC SP_GetTopFourFeature

GO
/****** Object:  StoredProcedure [dbo].[SP_SP_GetAllGuideType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Autho:        <Unknown>
-- Modify:		<Hasan>
-- Modify date: <06 May 2015 >
-- For Retriving  GuideLine Data Randomly  <Default Page>


/*****************************************************/

	CREATE PROCEDURE [dbo].[SP_SP_GetAllGuideType]

/*****************************************************/
As

BEGIN TRY 
-- exec SP_SP_GetAllGuideType 
		
-- Retrieve column specific information 

	SELECT guideType.IID, 
	       guideType.BusinessTypeID AS GuideTypeBusinessTypeID,
		   SUBSTRING(guideType.Title,0,30) +'...' AS GuideTypeTitle,
		   SUBSTRING (guideType.Description,0,30)+'...' AS GuideTypeDescription,
		   guideType.ImageUrl AS GuideTypeImage
		
	FROM GuideLine guideType		
	WHERE guideType.IsRemoved=0
	ORDER BY newid()

	--Google Nexus 7 pulled from Play
	--Google delivers major Chrome for 
	--Get a new boiler from British Gas...

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
/****** Object:  StoredProcedure [dbo].[SP_SP_GetAllLoanTypeForBankingNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_SP_GetAllLoanTypeForBankingNews

	*/
	CREATE PROCEDURE [dbo].[SP_SP_GetAllLoanTypeForBankingNews]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select loanType.IID, 
	   
		loanType.Name as LoanTypeName,
		loanType.Description as LoanTypeDescription,
		loanType.ImageUrl as LoanTypeImage
		
	from LoanType loanType		
	where
	LoanType.IsRemoved='false'
	
    
	END


GO
/****** Object:  StoredProcedure [dbo].[SP_SP_GetAllMortgageTypeForBankingNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC SP_SP_GetAllLoanTypeForBankingNews

	*/
	CREATE PROCEDURE [dbo].[SP_SP_GetAllMortgageTypeForBankingNews]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select mortgageType.IID, 
	   
		mortgageType.Name as MortgageTypeName,
		mortgageType.Description as MortgageTypeDescription,
		mortgageType.ImageUrl as MortgageTypeImage
		
	from MortgageTypeInfo mortgageType		

    
	END


GO
/****** Object:  StoredProcedure [dbo].[spDeleteFromUserGroup]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteFromUserGroup]
	
	(
		@id bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	Delete from UserGroup where IID=@id;
END



GO
/****** Object:  StoredProcedure [dbo].[SpDeleteUrlList]    Script Date: 6/23/2015 12:42:05 PM ******/
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
		@urlID int =  0 
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from UrlWFList where IID = @urlID
END


GO
/****** Object:  StoredProcedure [dbo].[SpGetAllCompanyInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <01 April 2015 >

CREATE PROC [dbo].[SpGetAllCompanyInformation]
As

BEGIN TRY 

-- Retrieve column specific information 

Select L.IID,
	   ISNULL(C.LogoUrl,'') LogoUrl,
       L.LoanTypeID,
	   L.LoanAmtYearScheduleID,
	   LY.APR, 
	   ISNULL(LType.[Description],' ') [Description],
	    ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl  
from  LoanInfo L
LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
WHERE L.IsRemoved=0

--SELECT  L.IID, 
--		C.LogoUrl, 
--		C.Name, 
--		L.LoanTypeID, 
--		LS.APR  ,
--		L.TotalReturnAmount, 
--		L.MonthlyReturnAmount, 
--		ISNULL (LF.Description,' ') as LoanFeature,
--		ISNULL (L.[Description],' ') as [Description],
--		ISNULL(( SELECT TOP 1 Loan.ImageUrl FROM LoanInfo Loan  WHERE Loan.IID=L.IID  ORDER BY Loan.IID ),' ') AS LoanTypeImageUrl 
		 
--FROM LoanInfo L
--LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
--LEFT JOIN LoanAmtYearSchedule LS on l.LoanAmtYearScheduleID=LS.IID
--LEFT JOIN LoanFeature LF on LF.LoanInfoID=L.IID
--WHERE L.IsRemoved=0


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
/****** Object:  StoredProcedure [dbo].[spGetAllDataAccordingToNetworkServiceProvider]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllDataAccordingToNetworkServiceProvider] 
	-- Add the parameters for the stored procedure here
	(
		@operatorID int 
	)
AS

BEGIN TRY

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

			SELECT  
				ISNULL(MPI.PictureUrl, '')PictureUrl, 
				CINFO.Name, 
				CINFO.IID,
				MPTYPE.TypeName,
				MPI.ModelName, 
				MPI.NetworkProviderID,
				MPI.ContractDuration,
				MPI.TotalTalkTime,
				MPI.TalkTimeUnitID,
				MPI.TotalTextMessage,
				MPI.TotalUsableData,
				MPI.UsableDataUnitID,
				MPI.MonthlyInstallmentAmt,
				MPI.RedirectUrl
		FROM MobilePhoneInfo MPI
		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
		WHERE MPI.NetworkProviderID=@operatorID

END

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
/****** Object:  StoredProcedure [dbo].[spGetAllGasDealForListView]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllGasDealForListView] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select gas.IsRemoved, gas.TradeName, gas.DealerName, gas.PhoneNo,gas.Address, comp.Name, dst.Name as DistrictName, gas.IID
	from 
	GasDealerInfo gas
	Left join
	CompanyInfo comp
	on gas.CompanyInfoID = comp.IID
	Left join
	District dst
	on gas.DistrictID = dst.IID

END


GO
/****** Object:  StoredProcedure [dbo].[spGetAllInfoAccordingToTalkTime]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllInfoAccordingToTalkTime] 
	-- Add the parameters for the stored procedure here
		(
			@minuteID int
		)
AS

BEGIN TRY

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  
				ISNULL(MPI.PictureUrl, '')PictureUrl, 
				(CINFO.Name+ ' '+ MPTYPE.TypeName+' '+MPI.ModelName) AS Name, 
				CINFO.IID,
				MPI.NetworkProviderID,
				MPI.ContractDuration,
				MPI.TotalTalkTime,
				MPI.TalkTimeUnitID,
				MPI.TotalTextMessage,
				MPI.TotalUsableData,
				MPI.UsableDataUnitID,
				MPI.MonthlyInstallmentAmt,
				MPI.RedirectUrl,
				CINFO.LogoUrl
		FROM MobilePhoneInfo MPI
		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
		WHERE MPI.TotalTalkTime>=@minuteID

		END
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
/****** Object:  StoredProcedure [dbo].[spGetAllInsuranceCarNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <11.05.15>
-- Description:	<Get All News About Car Insurance>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllInsuranceCarNews]
	-- Add the parameters for the stored procedure here
	
AS

BEGIN TRY
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 3 news.IID, news.TitleName, SUBSTRING((news.[Description]),0,35) as [Description], news.ImageUrl, news.BusinessTypeBreakdownID
	FROM AllNews news
	WHERE BusinessTypeID=4 AND BusinessTypeBreakdownID=3 and IsRemoved=0
	ORDER BY NEWID()

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
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[SpGetAllLoanDescriptionDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <07 April 2015 > Update 20 April
-- For Retriving All Loan <LoanDesciptionDetails Page>

CREATE PROC [dbo].[SpGetAllLoanDescriptionDetail]
(
	@LoanTypeID int=1,
	@Amount decimal,
	@Duration int 
)
As

BEGIN TRY 

-- Retrieve column specific information 
		
-----------------IF No Amount and Duration is Selected---------------------------
IF(@Amount=0 AND @Duration=0 )
BEGIN
	Select RowNumber,IID,LogoUrl,Name,LoanTypeID,LoanName,LoanAmtYearScheduleID,APR,TotalReturnAmount,MonthlyReturnAmount,[Description],LoanTypeImageUrl,WebAddress from 
	
	(Select ROW_NUMBER() OVER(ORDER BY L.IID) AS RowNumber, 
		   L.IID,
		   ISNULL(C.LogoUrl,'') LogoUrl,
		   C.Name,
		   L.LoanTypeID,
		   LType.Name as LoanName,
		   L.LoanAmtYearScheduleID,
		   LY.APR,
		   L.TotalReturnAmount, 
		   L.MonthlyReturnAmount, 
		   ISNULL(L.[Description],' ') [Description],
		   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
		   ISNULL(C.WebAddress,'')WebAddress   
	    
	from  LoanInfo L
	LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
	LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
	LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
	WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID
	) F
	--WHERE F.RowNumber>=@StartRowNumber and F.RowNumber<=@EndRowNumber
	Order by F.IID 
END
ELSE IF(@Amount<>0 AND @Duration<>0 )
BEGIN
	Select RowNumber,IID,LogoUrl,Name,LoanTypeID,LoanName,LoanAmtYearScheduleID,APR,TotalReturnAmount,MonthlyReturnAmount,[Description],LoanTypeImageUrl,WebAddress from 
	
	(Select ROW_NUMBER() OVER(ORDER BY L.IID) AS RowNumber, 
		   L.IID,
		   ISNULL(C.LogoUrl,'') LogoUrl,
		   C.Name,
		   L.LoanTypeID,
		   LType.Name as LoanName,
		   L.LoanAmtYearScheduleID,
		   LY.APR,
		   L.TotalReturnAmount, 
		   L.MonthlyReturnAmount, 
		   ISNULL(L.[Description],' ') [Description],
		   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
		   ISNULL(C.WebAddress,'')WebAddress   
	    
	from  LoanInfo L
	LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
	LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
	LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
	WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID
	AND @Amount Between LY.AmountStart and LY.AmountEnd 
	AND LY.Duration=@Duration
	) F
	--WHERE F.RowNumber>=@StartRowNumber and F.RowNumber<=@EndRowNumber
	Order by F.IID 
END
ELSE IF(@Amount=0 AND @Duration<>0 )
BEGIN
	Select RowNumber,IID,LogoUrl,Name,LoanTypeID,LoanName,LoanAmtYearScheduleID,APR,TotalReturnAmount,MonthlyReturnAmount,[Description],LoanTypeImageUrl,WebAddress from 
	
	(Select ROW_NUMBER() OVER(ORDER BY L.IID) AS RowNumber, 
		   L.IID,
		   ISNULL(C.LogoUrl,'') LogoUrl,
		   C.Name,
		   L.LoanTypeID,
		   LType.Name as LoanName,
		   L.LoanAmtYearScheduleID,
		   LY.APR,
		   L.TotalReturnAmount, 
		   L.MonthlyReturnAmount, 
		   ISNULL(L.[Description],' ') [Description],
		   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
		   ISNULL(C.WebAddress,'')WebAddress   
	    
	from  LoanInfo L
	LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
	LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
	LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
	WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID
	AND LY.Duration=@Duration
	) F
	--WHERE F.RowNumber>=@StartRowNumber and F.RowNumber<=@EndRowNumber
	Order by F.IID 
END

ELSE IF(@Amount<>0 AND @Duration=0 )
BEGIN
	Select RowNumber,IID,LogoUrl,Name,LoanTypeID,LoanName,LoanAmtYearScheduleID,APR,TotalReturnAmount,MonthlyReturnAmount,[Description],LoanTypeImageUrl,WebAddress from 
	
	(Select ROW_NUMBER() OVER(ORDER BY L.IID) AS RowNumber, 
		   L.IID,
		   ISNULL(C.LogoUrl,'') LogoUrl,
		   C.Name,
		   L.LoanTypeID,
		   LType.Name as LoanName,
		   L.LoanAmtYearScheduleID,
		   LY.APR,
		   L.TotalReturnAmount, 
		   L.MonthlyReturnAmount, 
		   ISNULL(L.[Description],' ') [Description],
		   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
		   ISNULL(C.WebAddress,'')WebAddress   
	    
	from  LoanInfo L
	LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
	LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
	LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
	WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID
	AND @Amount Between LY.AmountStart and LY.AmountEnd 
	) F
	--WHERE F.RowNumber>=@StartRowNumber and F.RowNumber<=@EndRowNumber
	Order by F.IID 
END

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
/****** Object:  StoredProcedure [dbo].[SpGetAllLoanDescriptionDetailPassingParameter]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <07 April 2015 >
-- For Retriving All Loan <LoanDesciptionDetails Page>

CREATE PROC [dbo].[SpGetAllLoanDescriptionDetailPassingParameter]
(
	@LoanTypeID int=1,
	@startRowNumber int,
	@maxRowNumber int
)
As

BEGIN TRY 

	Set @maxRowNumber = @startRowNumber+ @maxRowNumber
		
-- Retrieve column specific information 

Select F.RowNumber,F.IID,F.LogoUrl,
       F.Name,F.LoanTypeID,F.LoanName,
	   F.LoanAmtYearScheduleID,F.APR,
	   F.TotalReturnAmount,F.MonthlyReturnAmount,
	   F.[Description],F.LoanTypeImageUrl,F.WebAddress 
	   from 
	   (Select ROW_NUMBER() OVER(ORDER BY L.CompanyInfoID) AS RowNumber, 
			   L.IID,
			   ISNULL(C.LogoUrl,'') LogoUrl,
			   C.Name,
			   L.LoanTypeID,
			   LType.Name as LoanName,
			   L.LoanAmtYearScheduleID,
			   LY.APR,
			   L.TotalReturnAmount, 
			   L.MonthlyReturnAmount, 
			   ISNULL(L.[Description],' ') [Description],
			   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
			   ISNULL(C.WebAddress,'')WebAddress   
	    
		from  LoanInfo L
		LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
		LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
		LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
		WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID
	    ) F
WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
Order by F.IID 

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
/****** Object:  StoredProcedure [dbo].[SpGetAllLoanTypeInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <01 April 2015 >

CREATE PROC [dbo].[SpGetAllLoanTypeInformation]
As

BEGIN TRY 

-- Retrieve column specific information 


Select 
      LType.IID,
	  ISNULL(LType.[Description],' ') [Description],
	  ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=LType.IID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
	  LType.IsRemoved  
From  LoanType LType



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
/****** Object:  StoredProcedure [dbo].[SpGetAllMobileDetailByCompanynModel]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpGetAllMobileDetailByCompanynModel]
(
	@CompanyInfoID int,
	@ModelName nvarchar(50)
	
)
As

BEGIN TRY 

-- Retrieve column specific information 
--IF(@ModelName='ALL')
--BEGIN

--		SELECT ISNULL(MPI.PictureUrl, '')PictureUrl, 
--				CINFO.Name, 
--				MPTYPE.TypeName,
--				MPI.ModelName, 
--				MPI.NetworkProviderID,
--				MPI.ContractDuration,
--				MPI.TotalTalkTime,
--				MPI.TalkTimeUnitID,
--				MPI.TotalTextMessage,
--				MPI.TotalUsableData,
--				MPI.UsableDataUnitID,
--				MPI.MonthlyInstallmentAmt,
--				MPI.RedirectUrl
--		FROM MobilePhoneInfo MPI
--		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
--		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
--		WHERE MPI.CompanyInfoID=@CompanyInfoID and MPI.ModelName=@ModelName

--END
--ELSE 
BEGIN 
	
		SELECT  
				ISNULL(MPI.PictureUrl, '')PictureUrl, 
				(CINFO.Name+' '+MPTYPE.TypeName+' '+MPI.ModelName) AS Name, 
				CINFO.IID,
				MPI.NetworkProviderID,
				MPI.ContractDuration,
				MPI.TotalTalkTime,
				MPI.TalkTimeUnitID,
				MPI.TotalTextMessage,
				MPI.TotalUsableData,
				MPI.UsableDataUnitID,
				MPI.MonthlyInstallmentAmt,
				MPI.RedirectUrl
		FROM MobilePhoneInfo MPI
		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
		WHERE MPI.CompanyInfoID=@CompanyInfoID 	and MPI.ModelName=ModelName
END


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
/****** Object:  StoredProcedure [dbo].[spGetAllMobilePhoneInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <06.03.15>
-- Description:	<All Mobile Phone Feature Information>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllMobilePhoneInformation] 
	-- Add the parameters for the stored procedure here
	
AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY 

    -- Insert statements for procedure here
	Select Pinfo.IID,Pinfo.PictureUrl, ISNULL(Feature.[Description],'') [Description],MType.TypeName, Pinfo.ModelName
	from MobilePhoneInfo Pinfo
	Left Join MPFeature Feature on Pinfo.IID=Feature.MobilePhoneID
	Left Join MPType MType on Pinfo.MPTypeID=MType.IID

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
/****** Object:  StoredProcedure [dbo].[spGetAllMobilePhoneType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	/*

	EXEC spGetAllMobilePhoneType

	*/
	CREATE PROCEDURE [dbo].[spGetAllMobilePhoneType]
	
	AS
	BEGIN
	
	SET NOCOUNT ON;	

	select mpType.IID, 
	   
		mpType.TypeName as TypeName
		
		
	from MPType mpType		
	where
	mpType.IsRemoved='false'
	
    
	END

GO
/****** Object:  StoredProcedure [dbo].[spGetAllMobileTypeAndModelByCompanyInfoID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllMobileTypeAndModelByCompanyInfoID] 
	-- Add the parameters for the stored procedure here
	(
		@CompanyInfoID int 	
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select (MPType.TypeName+ '-' +MobilePhoneInfo.ModelName) AS Models, MPType.IID
from MPType
join MobilePhoneInfo
on MPType.CompanyInfoID = MobilePhoneInfo.CompanyInfoID
where MPType.CompanyInfoID=@CompanyInfoID AND MobilePhoneInfo.CompanyInfoID=@CompanyInfoID

END


GO
/****** Object:  StoredProcedure [dbo].[SpGetAllPoliceStation]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  StoredProcedure [dbo].[spGetAllProductsForIndividualManufacturer]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllProductsForIndividualManufacturer] 
	-- Add the parameters for the stored procedure here
	(
		@CompanyInfoID int
	)
AS

BEGIN TRY

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  
				ISNULL(MPI.PictureUrl, '')PictureUrl, 
				(CINFO.Name+ ' '+ MPTYPE.TypeName+' '+MPI.ModelName) AS Name, 
				CINFO.IID,
				MPI.NetworkProviderID,
				MPI.ContractDuration,
				MPI.TotalTalkTime,
				MPI.TalkTimeUnitID,
				MPI.TotalTextMessage,
				MPI.TotalUsableData,
				MPI.UsableDataUnitID,
				MPI.MonthlyInstallmentAmt,
				MPI.RedirectUrl,
				CINFO.LogoUrl
		FROM MobilePhoneInfo MPI
		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
		WHERE MPI.CompanyInfoID=@CompanyInfoID 	
END

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
/****** Object:  StoredProcedure [dbo].[SpGetAllSearchDataForMobile]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SpGetAllSearchDataForMobile]
(
	@TotalTalkTime          nvarchar(50),
	@TotalTextMessage       nvarchar(50),
	@TotalUsableData        nvarchar(50),
	@MonthlyInstallmentAmt  nvarchar(50),
	@UpfrontCost			nvarchar(50)
	
)
As

BEGIN TRY 
 
  IF(@TotalTalkTime!='Any' OR @TotalTextMessage!='Any'  )

	BEGIN 
			          
		SELECT ISNULL(MPI.PictureUrl, '')PictureUrl, 
		CINFO.Name, 
		CINFO.IID,
		MPTYPE.TypeName,
		MPI.ModelName, 
		MPI.NetworkProviderID,
		MPI.ContractDuration,
		MPI.TotalTalkTime,
		MPI.TalkTimeUnitID,
		MPI.TotalTextMessage,
		MPI.TotalUsableData,
		MPI.UsableDataUnitID,
		MPI.MonthlyInstallmentAmt,
		MPI.RedirectUrl
	FROM MobilePhoneInfo MPI
	left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
	left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID

	WHERE MPI.TotalTalkTime =   @TotalTalkTime AND        
   			MPI.TotalTextMessage =@TotalTextMessage AND     
			MPI.TotalUsableData= @TotalUsableData  AND
					  MPI.MonthlyInstallmentAmt = @MonthlyInstallmentAmt 
				--AND MPI.UpfrontCost	= @UpfrontCost	
	END

ELSE IF(@TotalTalkTime='Any' OR @TotalTextMessage='Any'  )

BEGIN
			          
		SELECT ISNULL(MPI.PictureUrl, '')PictureUrl, 
		CINFO.Name, 
		CINFO.IID,
		MPTYPE.TypeName,
		MPI.ModelName, 
		MPI.NetworkProviderID,
		MPI.ContractDuration,
		MPI.TotalTalkTime,
		MPI.TalkTimeUnitID,
		MPI.TotalTextMessage,
		MPI.TotalUsableData,
		MPI.UsableDataUnitID,
		MPI.MonthlyInstallmentAmt,
		MPI.RedirectUrl
	FROM MobilePhoneInfo MPI
	left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
	left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
END

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
/****** Object:  StoredProcedure [dbo].[spGetAllShoppingNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllShoppingNews]
	-- Add the parameters for the stored procedure here
	
AS

BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	select news.BusinessTypeBreakdownID, news.TitleName, news.Description, news.ImageUrl,CAST(news.CreatedDate as DATE) AS date 
	from AllNews news
	where news.BusinessTypeID = '3'-- AND news.BusinessTypeBreakdownID='1'
	order by CreatedDate
 
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
/****** Object:  StoredProcedure [dbo].[spGetAnyInformationRegardingMobilePhones]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAnyInformationRegardingMobilePhones] 
	-- Add the parameters for the stored procedure here
	(
		@CompanyInfoID int,
		@TypeName nvarchar(50),
		@ModelName nvarchar(50),
		@TotalTextMessage nvarchar(50),
		@TotalTalkTime int,
		@TotalUsableData int,
		@MonthlyInstallmentAmt int
		
	)

	--- 
	--Exec spGetAnyInformationRegardingMobilePhones 1014,'any','6 32GB','100', 100,1,7200
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@TypeName='Any')
	SET @TypeName=null

    -- Insert statements for procedure here
	SELECT  
				ISNULL(MPI.PictureUrl, '')PictureUrl, 
				(CINFO.Name+' '+MPTYPE.TypeName+' '+MPI.ModelName) AS Name, 
				CINFO.IID,
				MPI.NetworkProviderID,
				MPI.ContractDuration,
				MPI.TotalTalkTime,
				MPI.TalkTimeUnitID,
				MPI.TotalTextMessage,
				MPI.TotalUsableData,
				MPI.UsableDataUnitID,
				MPI.MonthlyInstallmentAmt,
				MPI.RedirectUrl
		FROM MobilePhoneInfo MPI
		left Join CompanyInfo CINFO ON MPI.CompanyInfoID=CINFO.IID
		left Join MPType MPTYPE ON MPI.MPTypeID=MPType.IID
		
		--WHERE MPI.TotalTextMessage  in (CASE 
		--								 WHEN @TotalTextMessage <>'any'  
		--								 THEN  
		--								  @TotalTextMessage 
										
		--								 ELSE
		--									  (Select TotalTextMessage from  MobilePhoneInfo)
		--								 END		   
		--						     )  OR
		--		MPI.CompanyInfoID in (CASE
		--							  WHEN @CompanyInfoID <> 'any'
		--							  THEN
		--								@CompanyInfoID
		--							  ELSE
		--								(Select IID from CompanyInfo)
		--								END
		--							 )OR

		--		MPI.ModelName in (CASE
		--							WHEN @ModelName <> 'any'
		--							THEN
		--								@ModelName
		--							ELSE
		--								(select ModelName from MobilePhoneInfo)
		--							END
		--						 )
         
				
		-- MPI.CompanyInfoID=@CompanyInfoID 	and MPI.ModelName=ModelName



		--WHERE TotalTextMessage=@TotalTextMessage
		--AND
		--CASE
		--	WHEN @CompanyInfoID IS NOT NULL THEN CompanyInfoID= @CompanyInfoID
		--	WHEN @TypeName IS NOT NULL THEN  = @CompanyInfoID
		--	WHEN @ModelName IS NOT NULL THEN CompanyInfoID= @CompanyInfoID
  --          WHEN @TotalTextMessage Is Not Null THEN SiteId = @SiteId
		--	WHEN @TotalTalkTime Is Not Null THEN SiteId = @SiteId
		--	WHEN @TotalUsableData Is Not Null THEN SiteId = @SiteId
		--	WHEN @MonthlyInstallmentAmt Is Not Null THEN SiteId = @SiteId

		--END

		WHERE 
		  MPI.CompanyInfoID = ISNULL(@CompanyInfoID, MPI.CompanyInfoID)
		  --AND (CASE WHEN @CompanyInfoID=0 THEN 0 ELSE  MPI.CompanyInfoID END)=@CompanyInfoID
		  AND MPI.ModelName      = ISNULL(@ModelName, ModelName)
		  AND MPTYPE.TypeName     = ISNULL(@TypeName, TypeName)
		  AND MPI.TotalTextMessage = ISNULL(@TotalTextMessage, TotalTextMessage)
		  AND MPI.TotalTalkTime = ISNULL(@TotalTalkTime, TotalTalkTime)
		  AND MPI.TotalUsableData = ISNULL(@TotalUsableData, TotalUsableData)
		  AND MPI.MonthlyInstallmentAmt = ISNULL(@MonthlyInstallmentAmt, MonthlyInstallmentAmt)
END

GO
/****** Object:  StoredProcedure [dbo].[spGetCarInsuranceQuotes]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCarInsuranceQuotes] 
	-- Add the parameters for the stored procedure here
	@CartypeID int,
	@CarConditionID int,
	@Run bigint,
	@CarAge int,
	@CarValueAmount money,
	@PremiumTotalPercent float,
	@Duration int

AS

BEGIN TRY

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select  car.IID ,cmp.LogoUrl, CompanyInfoID, car.CarValueAmount, car.FixedTotalAmount, car.FixedVoluntaryAmount, car.FixedCompulsoryAmount, car.AnnuallyGrossAmount, car.TotalMonth, car.InstallmentAmount
	from
	CarInsurance car
	LEFT JOIN 
	CarInsuranceParameter ins
	ON car.CarInsuranceParameterID=ins.IID
	LEFT JOIN CompanyInfo cmp
	ON cmp.IID=car.CompanyInfoID 
	where ins.CarTypeID=@CartypeID AND ins.CarConditionID=@CarConditionID AND @Run Between ins.MinRun AND ins.MaxRun
	AND @CarAge Between ins.MinCarAge AND ins.MaxCarAge AND @CarValueAmount Between ins.MinCarValueAmount AND ins.MaxCarValueAmount
	AND ins.PremiumTotalPercent=@PremiumTotalPercent AND ins.Duration=@Duration
	
	


END

END TRY

BEGIN CATCH 

BEGIN


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

END

END CATCH


GO
/****** Object:  StoredProcedure [dbo].[spGetModelNameByCompanyName]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetModelNameByCompanyName] 
	-- Add the parameters for the stored procedure here
(
	@CompanyInfoID int
)
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN
	select MPType.TypeName 
	from MPType
	Join CompanyInfo On MPType.CompanyInfoID=@CompanyInfoID
END


GO
/****** Object:  StoredProcedure [dbo].[SpGetRandomAllNewsRowsByBusinessTypeID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <2/15/2015 >

CREATE PROC [dbo].[SpGetRandomAllNewsRowsByBusinessTypeID]
(
	@BusinessTypeID int
)
As

BEGIN TRY 

-- Retrieve column specific information 

	SELECT  IID,BusinessTypeID,ISNULL (TitleName,' ')AS TitleName , ISNULL ([Description],'') AS [Description], ImageUrl,BusinessTypeBreakdownID 
	FROM AllNews
	WHERE BusinessTypeID = @BusinessTypeID AND IsRemoved = 0
	order by NEWID()
	


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
/****** Object:  StoredProcedure [dbo].[SpGetSortedAllNewsDetailsForNewsID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <23 April 2015 >
-- For Retriving All Loan <AllNewsDetails Page>

CREATE PROC [dbo].[SpGetSortedAllNewsDetailsForNewsID]
(
	@AllNewsIId int,
	@startRowNumber int,
	@maxRowNumber int
)
As
---SpGetSortedAllNewsDetailsForNewsID 2,0,10
BEGIN TRY 

	Set @maxRowNumber = @startRowNumber+ @maxRowNumber
		
-- Retrieve column specific information 

Select F.RowNumber,F.IID,F.AllNewsID,F.TitleName,F.[Description],F.ImageUrl,F.CreatedDate
	   from 
	      (Select ROW_NUMBER() OVER(ORDER BY AllNewsDetail.IID) AS RowNumber,
			      IID,
				  AllNewsID,
				  ISNULL (TitleName,' ') AS TitleName, 
				  ISNULL([Description],' ')AS [Description],
				  ISNULL (ImageUrl,' ') AS ImageUrl,
				  CreatedDate
			      FROM AllNewsDetail
				  WHERE AllNewsID=@AllNewsIId AND IsRemoved=0 
	       ) F
WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
Order by F.IID 

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
/****** Object:  StoredProcedure [dbo].[spGetTopOneMobilePhoneInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <06.03.15>
-- Description:	<All Mobile Phone Feature Information>
-- =============================================
CREATE PROCEDURE [dbo].[spGetTopOneMobilePhoneInformation] 
	-- Add the parameters for the stored procedure here
	
AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN  

    -- Insert statements for procedure here
	Select Pinfo.TotalPrice,  Pinfo.IID,Pinfo.PictureUrl, ISNULL(Feature.[Description],'') [Description],MType.TypeName, Pinfo.ModelName
	from MobilePhoneInfo Pinfo
	Left Join MPFeature Feature on Pinfo.IID=Feature.MobilePhoneID
	Left Join MPType MType on Pinfo.MPTypeID=MType.IID

	END 

--exec spGetTopOneMobilePhoneInformation

GO
/****** Object:  StoredProcedure [dbo].[spGetTopTenMobilePhoneInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <06.03.15>
-- Description:	<All Mobile Phone Feature Information>
-- =============================================
CREATE PROCEDURE [dbo].[spGetTopTenMobilePhoneInformation] 
	-- Add the parameters for the stored procedure here
	
AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN  

    -- Insert statements for procedure here
	Select top 10 Pinfo.TotalPrice,  Pinfo.IID,Pinfo.PictureUrl, ISNULL(Feature.[Description],'') [Description],MType.TypeName, Pinfo.ModelName
	from MobilePhoneInfo Pinfo
	Left Join MPFeature Feature on Pinfo.IID=Feature.MobilePhoneID
	Left Join MPType MType on Pinfo.MPTypeID=MType.IID

	END 

--exec spGetTopOneMobilePhoneInformation

GO
/****** Object:  StoredProcedure [dbo].[SpSearchAllLoanDescriptionDetailPassingParameter]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Hasan>
-- Create date: <07 April 2015 >
-- For Retriving All Loan <LoanDesciptionDetails Page>

CREATE PROC [dbo].[SpSearchAllLoanDescriptionDetailPassingParameter]
(
	@LoanTypeID int=1,
	@Amount decimal,
	@Duration int, 
	@startRowNumber int,
	@maxRowNumber int
)
As
--- Exec SpSearchAllLoanDescriptionDetailPassingParameter 1, 5200000.00,0,0,10 
BEGIN TRY 

	Set @maxRowNumber = @startRowNumber+ @maxRowNumber
		
-- Retrieve column specific information 

 IF(@Amount= 0 AND @Duration = 0)
	BEGIN
		Select F.RowNumber,F.IID,F.LogoUrl,
			   F.Name,F.LoanTypeID,F.LoanName,
			   F.LoanAmtYearScheduleID,F.APR,
			   F.TotalReturnAmount,F.MonthlyReturnAmount,
			   F.[Description],F.LoanTypeImageUrl,F.WebAddress 
			   from 
			   (Select ROW_NUMBER() OVER(ORDER BY L.CompanyInfoID) AS RowNumber, 
					   L.IID,
					   ISNULL(C.LogoUrl,'') LogoUrl,
					   C.Name,
					   L.LoanTypeID,
					   LType.Name as LoanName,
					   L.LoanAmtYearScheduleID,
					   LY.APR,
					   L.TotalReturnAmount, 
					   L.MonthlyReturnAmount, 
					   ISNULL(L.[Description],' ') [Description],
					   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
					   ISNULL(L.RedirectUrl,' ')WebAddress   
	    
				from  LoanInfo L
				LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
				LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
				LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
				WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID 
				) F
		WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
		Order by F.IID 
	END

ELSE IF(@Amount<>0 AND @Duration<>0)
	BEGIN
		Select F.RowNumber,F.IID,F.LogoUrl,
			   F.Name,F.LoanTypeID,F.LoanName,
			   F.LoanAmtYearScheduleID,F.APR,
			   F.TotalReturnAmount,F.MonthlyReturnAmount,
			   F.[Description],F.LoanTypeImageUrl,F.WebAddress 
			   from 
			   (Select ROW_NUMBER() OVER(ORDER BY L.CompanyInfoID) AS RowNumber, 
					   L.IID,
					   ISNULL(C.LogoUrl,'') LogoUrl,
					   C.Name,
					   L.LoanTypeID,
					   LType.Name as LoanName,
					   L.LoanAmtYearScheduleID,
					   LY.APR,
					   L.TotalReturnAmount, 
					   L.MonthlyReturnAmount, 
					   ISNULL(L.[Description],' ') [Description],
					   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
					   ISNULL(C.WebAddress,'')WebAddress   
	    
				from  LoanInfo L
				LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
				LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
				LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
				WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID and @Amount Between LY.AmountStart and LY.AmountEnd and LY.Duration=@Duration
				) F
		WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
		Order by F.IID 
	END

ELSE IF(@Amount=0 AND @Duration<>0)
	BEGIN
		Select F.RowNumber,F.IID,F.LogoUrl,
			   F.Name,F.LoanTypeID,F.LoanName,
			   F.LoanAmtYearScheduleID,F.APR,
			   F.TotalReturnAmount,F.MonthlyReturnAmount,
			   F.[Description],F.LoanTypeImageUrl,F.WebAddress 
			   from 
			   (Select ROW_NUMBER() OVER(ORDER BY L.CompanyInfoID) AS RowNumber, 
					   L.IID,
					   ISNULL(C.LogoUrl,'') LogoUrl,
					   C.Name,
					   L.LoanTypeID,
					   LType.Name as LoanName,
					   L.LoanAmtYearScheduleID,
					   LY.APR,
					   L.TotalReturnAmount, 
					   L.MonthlyReturnAmount, 
					   ISNULL(L.[Description],' ') [Description],
					   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
					   ISNULL(C.WebAddress,'')WebAddress   
	    
				from  LoanInfo L
				LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
				LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
				LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
				WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID and LY.Duration=@Duration
				) F
		WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
		Order by F.IID 
	END

ELSE IF(@Amount<>0 AND @Duration=0)
	BEGIN
		Select F.RowNumber,F.IID,F.LogoUrl,
			   F.Name,F.LoanTypeID,F.LoanName,
			   F.LoanAmtYearScheduleID,F.APR,
			   F.TotalReturnAmount,F.MonthlyReturnAmount,
			   F.[Description],F.LoanTypeImageUrl,F.WebAddress 
			   from 
			   (Select ROW_NUMBER() OVER(ORDER BY L.CompanyInfoID) AS RowNumber, 
					   L.IID,
					   ISNULL(C.LogoUrl,'') LogoUrl,
					   C.Name,
					   L.LoanTypeID,
					   LType.Name as LoanName,
					   L.LoanAmtYearScheduleID,
					   LY.APR,
					   L.TotalReturnAmount, 
					   L.MonthlyReturnAmount, 
					   ISNULL(L.[Description],' ') [Description],
					   ISNULL(( SELECT TOP 1 T.ImageUrl FROM LoanType T  WHERE T.IID=L.LoanTypeID  ORDER BY T.IID ),' ') AS LoanTypeImageUrl,
					   ISNULL(C.WebAddress,'')WebAddress   
	    
				from  LoanInfo L
				LEFT JOIN CompanyInfo C on L.CompanyInfoID=C.IID
				LEFT JOIN LoanType LType on L.LoanTypeID=LType.IID
				LEFT JOIN LoanAmtYearSchedule LY on L.LoanAmtYearScheduleID=LY.IID
				WHERE L.IsRemoved=0 and L.LoanTypeID=@LoanTypeID and @Amount Between LY.AmountStart and LY.AmountEnd
				) F
		WHERE F.RowNumber>=@startRowNumber+1 and F.RowNumber<=@maxRowNumber
		Order by F.IID 
	END


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
/****** Object:  StoredProcedure [dbo].[spUserAccountPassword]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<User Password Change>
-- =============================================
CREATE PROCEDURE [dbo].[spUserAccountPassword]
	(
		@userEmailId nvarchar(50),
		@LoginPassword nvarchar(250)
	)
AS
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
/****** Object:  StoredProcedure [dbo].[UpadateInterestRateTypeByMortgageID]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Tanvir>
-- Create date: <29.03.15>
-- Description:	<Delete User Group>
-- =============================================
CREATE PROCEDURE [dbo].[UpadateInterestRateTypeByMortgageID]
	
	(
		@MortgageIID bigint
	)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE  dbo.[MortgageInterestRate] 
	SET dbo.[MortgageInterestRate].IsRemoved = 1
	where dbo.[MortgageInterestRate].MortgageID = @MortgageIID
END

GO
/****** Object:  Table [dbo].[AdLogInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdLogInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BussinessDescription] [nvarchar](2000) NULL,
	[DisplayOnPageID] [int] NOT NULL,
	[LogoUrl] [nvarchar](500) NOT NULL,
	[ContactPhoneNo] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[WebAddress] [nvarchar](500) NULL,
	[PayAmount] [money] NOT NULL,
	[DisplayStartDate] [datetime] NOT NULL,
	[DisplayEndDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AdLogInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllFeature](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessTypeID] [int] NOT NULL,
	[BusinessTypeBreakdownID] [int] NULL,
	[TitleName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](999) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AllFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllFeatureDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllFeatureDetail](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[AllFeatureID] [int] NOT NULL,
	[TitleName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](999) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AllFeatureDetail] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllNews](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessTypeID] [int] NOT NULL,
	[BusinessTypeBreakdownID] [int] NULL,
	[TitleName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](999) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AllNews] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllNewsDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllNewsDetail](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[AllNewsID] [int] NOT NULL,
	[TitleName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](999) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_AllNewsDetail] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Applicant]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applicant](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[MiddleName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](500) NOT NULL,
	[FatherName] [nvarchar](500) NULL,
	[MotherName] [nvarchar](500) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[GenderID] [int] NOT NULL,
	[SmokingHistoryID] [int] NULL,
	[ApplicationFor] [int] NOT NULL,
	[IPNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](999) NULL,
	[EmailAddress] [nvarchar](500) NOT NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[HomePhoneNo] [nvarchar](50) NULL,
	[ProfessionID] [int] NULL,
	[WantMoreInfoID] [int] NOT NULL,
	[HaveAdditionalJob] [bit] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_Applicant] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BDChannelInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BDChannelInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[SerialNo] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Note] [nvarchar](999) NULL,
	[ContactPhone] [nvarchar](50) NULL,
	[Address] [nvarchar](999) NULL,
	[WebAddress] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BDChannelInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BDInternet]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BDInternet](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProviderID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[PackageName] [nvarchar](500) NULL,
	[PackageImageUrl] [nvarchar](999) NULL,
	[NetSpeed] [int] NOT NULL,
	[NetSpeedUnitID] [int] NOT NULL,
	[DownloadSpeed] [int] NOT NULL,
	[DownloadSpeedUnitID] [int] NOT NULL,
	[DataAmount] [nvarchar](500) NULL,
	[NetGenerationID] [int] NOT NULL,
	[ContractDuration] [int] NULL,
	[ContractTypeID] [int] NULL,
	[ContractNote] [nvarchar](50) NULL,
	[ChargeTypeID] [int] NOT NULL,
	[ChargeTypeNote] [nvarchar](500) NULL,
	[ChargeAmount] [money] NULL,
	[TotalChannelNo] [int] NULL,
	[RedirectUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BDInternet] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BDInternetAndChannelMapping]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BDInternetAndChannelMapping](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BDInternetID] [bigint] NOT NULL,
	[BDChannelInfoID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BDInternetAndChannelMapping] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIAmountRange]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIAmountRange](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeID] [int] NOT NULL,
	[AmountStart] [money] NULL,
	[AmountEnd] [money] NOT NULL,
	[AmountDetail] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BIAmountRange] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIBusinessAge]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIBusinessAge](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[AgeInterval] [nvarchar](500) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BIBusinessAge] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BICategory]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BICategory](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BICategory] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BICategoryDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BICategoryDetail](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BICategoryID] [bigint] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BICategoryDetail] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIEmployeeLiability]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIEmployeeLiability](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountDetail] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BIEmployeeLiability] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIOfficeEquipment]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIOfficeEquipment](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountDetail] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BIOfficeEquipment] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIPublicLiability]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIPublicLiability](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount] [money] NOT NULL,
	[AmountDetail] [nvarchar](200) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BIPublicLiability] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessInsurance]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessInsurance](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BusinessInsurance] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessInsuranceReceiver]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessInsuranceReceiver](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicantID] [bigint] NOT NULL,
	[BICategoryDetailID] [bigint] NOT NULL,
	[BIBusinessAgeID] [bigint] NOT NULL,
	[YearWiseTurnoverAmt] [money] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BusinessInsuranceReceiver] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusinessInsuranceReceiverDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessInsuranceReceiverDetail](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[BusinessInsuranceReceiverID] [bigint] NOT NULL,
	[BIAmountRangeID] [bigint] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_BusinessInsuranceReceiverDetail] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarBrand]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarBrand](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ManufactureName] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarBrand] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardBalanceTransfer]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardBalanceTransfer](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CardInfoID] [bigint] NOT NULL,
	[MonthNumber] [int] NOT NULL,
	[TransferFeePercent] [money] NOT NULL,
	[Note] [nvarchar](500) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardBalanceTransfer] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardFeature](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CardInfoID] [bigint] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CardTypeID] [int] NOT NULL,
	[BalanceTypeID] [int] NOT NULL,
	[CardLogoUrl] [nvarchar](2000) NULL,
	[APR] [money] NOT NULL,
	[APRDescription] [nvarchar](500) NULL,
	[MinimumLimitAmt] [money] NOT NULL,
	[MaximumLimitAmt] [money] NOT NULL,
	[AnnualFeePayment] [money] NOT NULL,
	[RewardNote] [nvarchar](500) NULL,
	[RewardCompanyLogoUrl] [nvarchar](2000) NULL,
	[CashbackEarnedAmt] [money] NULL,
	[CashbackEarnedNote] [nvarchar](500) NULL,
	[WholeWorldUsageFeePer] [money] NULL,
	[UsedRemarkedPoint] [float] NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[IsVerified] [bit] NULL,
	[VerifiedBy] [bigint] NULL,
	[RedirectUrl] [nvarchar](2000) NULL,
	[TotalVisitor] [int] NULL,
	[IsPostAdExtended] [bit] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardPostDisplayHistory]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardPostDisplayHistory](
	[IID] [bigint] NOT NULL,
	[CardInfoID] [bigint] NOT NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardPostDisplayHistory] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardPurchase]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardPurchase](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CardInfoID] [bigint] NOT NULL,
	[MonthNumber] [int] NOT NULL,
	[RateOnPurchase] [float] NOT NULL,
	[Note] [nvarchar](500) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardPurchase] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardRegionWiseFee]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardRegionWiseFee](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CardInfoID] [bigint] NOT NULL,
	[RegionID] [int] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[UsageFeePercent] [money] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CardRegionWiseFee] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarDriving]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarDriving](
	[IID] [bigint] NOT NULL,
	[ApplicantID] [bigint] NOT NULL,
	[DrivingLicenceNo] [nvarchar](200) NULL,
	[PolicyStartDate] [datetime] NOT NULL,
	[LicenceTypeID] [int] NOT NULL,
	[LicenceYear] [int] NOT NULL,
	[NoClaimDiscountYear] [int] NOT NULL,
	[AffectDrivingID] [int] NOT NULL,
	[HasDeclinedIsurance] [bit] NOT NULL,
	[DriveOtherCar] [int] NULL,
	[PremiumPayTypeID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarDriving] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarInformation]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarInformation](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicantID] [bigint] NOT NULL,
	[RegistrationNumber] [nvarchar](200) NULL,
	[ManufacturingYear] [int] NOT NULL,
	[CarBrandID] [int] NOT NULL,
	[ModelName] [nvarchar](200) NOT NULL,
	[UsingCarFor] [int] NOT NULL,
	[RunMilesPerYear] [int] NOT NULL,
	[ParkingPlaceID] [int] NOT NULL,
	[IsSelfDrive] [bit] NULL,
	[NumberOfCar] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarInformation] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarInsurance]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarInsurance](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[CarInsuranceParameterID] [int] NOT NULL,
	[CarValueAmount] [money] NULL,
	[FixedTotalAmount] [money] NOT NULL,
	[FixedVoluntaryAmount] [money] NOT NULL,
	[FixedCompulsoryAmount] [money] NOT NULL,
	[AnnuallyGrossAmount] [money] NOT NULL,
	[TotalMonth] [int] NOT NULL,
	[InstallmentAmount] [money] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarInsurance] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarInsuranceFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarInsuranceFeature](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CarInsuranceID] [bigint] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarInsuranceFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarInsuranceParameter]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarInsuranceParameter](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CarTypeID] [int] NOT NULL,
	[CarConditionID] [int] NOT NULL,
	[MinRun] [bigint] NOT NULL,
	[MaxRun] [bigint] NOT NULL,
	[MinCarAge] [int] NOT NULL,
	[MaxCarAge] [int] NOT NULL,
	[MinCarValueAmount] [money] NOT NULL,
	[MaxCarValueAmount] [money] NOT NULL,
	[PremiumTotalPercent] [float] NOT NULL,
	[Duration] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarInsuranceParameter] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarModelInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModelInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CarBrandID] [int] NOT NULL,
	[ModelName] [nvarchar](200) NOT NULL,
	[FuelTypeID] [int] NOT NULL,
	[TransmissionModeID] [int] NOT NULL,
	[BodyType] [nvarchar](200) NOT NULL,
	[EnginePower] [nvarchar](200) NOT NULL,
	[NumberOfDoors] [int] NOT NULL,
	[ManufacturingYear] [int] NOT NULL,
	[NumberOfWheel] [int] NULL,
	[WheelSize] [float] NULL,
	[WheelSizeUnitID] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CarModelInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMSContent]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[CommunityNews]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommunityNews](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[NewsTypeID] [int] NOT NULL,
	[NewsType] [nvarchar](100) NOT NULL,
	[Image] [nvarchar](200) NULL,
	[VideoLink] [nvarchar](max) NULL,
	[HeadLine] [nvarchar](500) NOT NULL,
	[NewsDescription] [ntext] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[IsOnlyVideo] [bit] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CommunityNews] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[BussinessDescription] [nvarchar](2000) NULL,
	[OriginCountryID] [int] NULL,
	[EstablishedYear] [int] NULL,
	[TotalCountryBussCover] [int] NOT NULL,
	[BussinessTypeID] [int] NOT NULL,
	[LogoUrl] [nvarchar](500) NOT NULL,
	[ContactPhoneNo] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[WebAddress] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[District]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[DivisionOrState]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[error_log]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[error_log](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NULL,
	[Source] [nvarchar](200) NULL,
	[ErrMsg] [nvarchar](500) NULL,
 CONSTRAINT [PK_error_log] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GasAvailableArea]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GasAvailableArea](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[GasCylienderID] [bigint] NOT NULL,
	[AreaName] [nvarchar](500) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GasAvailableArea] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GasCyliender]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GasCyliender](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[AreaInfo] [nvarchar](999) NULL,
	[WeightOfGas] [float] NOT NULL,
	[WeightOfContainer] [float] NOT NULL,
	[RetailPrice] [money] NOT NULL,
	[PriceNote] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[RedirectUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GasCyliender] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GasCylinderAndDealerInfoMapping]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GasCylinderAndDealerInfoMapping](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[GasCylinderID] [bigint] NOT NULL,
	[GasDealerInfoID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GasCylinderAndDealerInfoMapping] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GasDealerInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GasDealerInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[TradeName] [nvarchar](500) NOT NULL,
	[DealerName] [nvarchar](500) NOT NULL,
	[PhoneNo] [nvarchar](50) NULL,
	[Address] [nvarchar](999) NOT NULL,
	[DistrictID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GasDealerInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GuideLine]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuideLine](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessTypeID] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [ntext] NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GuideLine] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GuideLineDetail]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuideLineDetail](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[GuideLineID] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[Description] [ntext] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GuideLineDetail] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GuideLineDetailMore]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuideLineDetailMore](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[GuideLineDetailID] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[ImageUrl] [nvarchar](999) NULL,
	[Description] [ntext] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_GuideLineDetailMore] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HelpAdvice]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HelpAdvice](
	[IID] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_HelpAdvice] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HomeInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomeInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicantID] [bigint] NOT NULL,
	[FloorNumberOfBuilding] [int] NOT NULL,
	[FloorSize] [int] NOT NULL,
	[FloorSizeUnitID] [int] NOT NULL,
	[RoomNumberPerFloor] [int] NULL,
	[ParkingSpaceSize] [int] NULL,
	[ParkingSpaceSizeUnitID] [int] NULL,
	[TotalFloorSize] [int] NOT NULL,
	[AddressOfBuilding] [nvarchar](900) NOT NULL,
	[PowerSupplyTypeID] [int] NULL,
	[WaterSupplyTypeID] [int] NULL,
	[GasSupplyTypeID] [int] NULL,
	[ConstructionDate] [datetime] NOT NULL,
	[EstimatedPrice] [money] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_HomeInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LIApplicableFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LIApplicableFeature](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[LISchemaID] [int] NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LIApplicableFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LifeInsurance]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LifeInsurance](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[LISchemaID] [int] NOT NULL,
	[PackageName] [nvarchar](250) NULL,
	[TotalCoverAmount] [money] NOT NULL,
	[CriticalillnessCoverAmount] [money] NULL,
	[IsGuranteedPremium] [bit] NOT NULL,
	[ClaimsPaidPercent] [nvarchar](150) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LifeInsurance] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LISchema]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LISchema](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfYear] [int] NOT NULL,
	[AgeMin] [int] NOT NULL,
	[AgeMax] [int] NOT NULL,
	[UnitAmount] [money] NOT NULL,
	[MultiplyFactor] [int] NOT NULL,
	[UnitPremiumAmount] [money] NOT NULL,
	[UnitReturnAmount] [money] NOT NULL,
	[PremiumPolicyID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LISchema] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanAmtYearSchedule]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanAmtYearSchedule](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[AmountStart] [money] NOT NULL,
	[AmountEnd] [money] NOT NULL,
	[Duration] [int] NOT NULL,
	[APR] [money] NOT NULL,
	[APRNote] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LoanAmtYearSchedule] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanFeature](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[LoanInfoID] [bigint] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LoanFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[LoanTypeID] [int] NOT NULL,
	[LoanAmtYearScheduleID] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[TotalAmount] [money] NULL,
	[TotalInstallmentNo] [int] NULL,
	[MonthlyReturnAmount] [money] NULL,
	[TotalReturnAmount] [money] NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[IsVerified] [bit] NULL,
	[VerifiedBy] [bigint] NULL,
	[RedirectUrl] [nvarchar](2000) NULL,
	[TotalVisitor] [int] NULL,
	[IsPostAdExtended] [bit] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LoanInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanPostDisplayHistory]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanPostDisplayHistory](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[LoanInfoID] [bigint] NOT NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LoanPostDisplayHistory] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoanType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanType](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_LoanType] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/23/2015 12:42:05 PM ******/
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
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MobilePhoneInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MobilePhoneInfo](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[NetworkProviderID] [int] NULL,
	[MPTypeID] [int] NOT NULL,
	[SIMAvailableID] [int] NOT NULL,
	[ModelName] [nvarchar](200) NULL,
	[TotalTalkTime] [int] NULL,
	[TalkTimeUnitID] [int] NULL,
	[TotalTextMessage] [int] NULL,
	[TotalUsableData] [decimal](10, 2) NULL,
	[UsableDataUnitID] [int] NULL,
	[ConnectionTypeID] [int] NULL,
	[TotalPrice] [money] NOT NULL,
	[ContractDuration] [int] NULL,
	[MonthlyInstallmentAmt] [money] NULL,
	[WarrantyInfo] [nvarchar](200) NULL,
	[PictureUrl] [nvarchar](2000) NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[IsVerified] [bit] NULL,
	[VerifiedBy] [bigint] NULL,
	[RedirectUrl] [nvarchar](2000) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_MobilePhoneInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mortgage]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mortgage](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyInfoID] [int] NOT NULL,
	[OperationTypeID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[APR] [float] NULL,
	[TermYearID] [int] NULL,
	[PaymentTypeID] [int] NOT NULL,
	[FeeOrCharge] [money] NULL,
	[Description] [nvarchar](500) NULL,
	[LTV] [float] NULL,
	[PropertyValueMinAmt] [money] NULL,
	[PropertyValueMaxAmt] [money] NULL,
	[MonthlyInstallmentAmt] [money] NULL,
	[IsPostAdExtended] [bit] NULL,
	[PostAdDate] [datetime] NOT NULL,
	[PostLastDisplayDate] [datetime] NOT NULL,
	[PaymentAmt] [money] NULL,
	[IsVerified] [bit] NULL,
	[VerifiedBy] [bigint] NULL,
	[RedirectUrl] [nvarchar](2000) NULL,
	[TotalVisitor] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
	[ImageUrl] [image] NULL,
 CONSTRAINT [PK_Mortgage] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MortgageInterestRate]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MortgageInterestRate](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[MortgageID] [bigint] NOT NULL,
	[UptoYear] [int] NOT NULL,
	[InterestRateTypeID] [int] NOT NULL,
	[Rate] [float] NOT NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_MortgageInterestRate] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MortgageTermYear]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MortgageTermYear](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfYear] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_MortgageTermYear] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MortgageTypeInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MortgageTypeInfo](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[ImageUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_MortgageTypeInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MPFeature]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MPFeature](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[MobilePhoneID] [bigint] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_MPFeature] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MPType]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MPType](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](200) NULL,
	[CompanyInfoID] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsRemoved] [bit] NOT NULL,
 CONSTRAINT [PK_MPType] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsLetterSubscribe]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsLetterSubscribe](
	[IID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](200) NOT NULL,
	[IsSubscribe] [bit] NOT NULL,
	[SubscribeDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_NewsLetterSubscribe] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OiiOMart]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OiiOMart](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Logo] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OiiOMart] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoliceStation]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[PostOffice]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[Profession]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[UrlWFList]    Script Date: 6/23/2015 12:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrlWFList](
	[IID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](250) NOT NULL,
	[ModuleNote] [nvarchar](200) NOT NULL,
	[ModuleImage] [nvarchar](300) NOT NULL,
	[ModuleSerialNo] [int] NOT NULL,
	[UrlWFName] [nvarchar](900) NOT NULL,
	[UrlWFSerialNo] [int] NOT NULL,
	[UrlWFDisplayName] [nvarchar](250) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[UrlModuleName] [nvarchar](300) NULL,
 CONSTRAINT [PK_UrlWFList] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
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
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[IID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserWFPermission]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[VisitorCounter]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[VisitorInfo]    Script Date: 6/23/2015 12:42:05 PM ******/
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
/****** Object:  Table [dbo].[VisitorInfoDetails]    Script Date: 6/23/2015 12:42:05 PM ******/
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
SET IDENTITY_INSERT [dbo].[AdLogInfo] ON 

INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'Dbbl Brand Logo', N'Dbbl Brand Logo Description', 2, N'~/All Photos/Logo/20150430111710851858553325325.jpg', N'01686845654', N'Dhanmondi, Dhaka', N'www.dutchbanglabank.com/', 50000.0000, CAST(0x0000A46D00000000 AS DateTime), CAST(0x0000A46E00000000 AS DateTime), 1, CAST(0x0000A4890109A6B9 AS DateTime), 1, CAST(0x0000A48A00EE996A AS DateTime), 0)
INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'HSBC', N'HSBC Official Bank Logo', 3, N'~/All Photos/Logo/20150430111600626447553325325.png', N'018647645454', N'House # 32, Road # 100  Gulshan-2, Dhaka-1212', N'www.hsbc.com', 150000.0000, CAST(0x0000A46D00000000 AS DateTime), CAST(0x0000A46E00000000 AS DateTime), 1, CAST(0x0000A489010A3C25 AS DateTime), 1, CAST(0x0000A48A00EEF8EB AS DateTime), 0)
INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'Samsung', N'Samsung Bd Logo', 2, N'~/All Photos/Logo/20150430143125892081553325325.png', N'018854645456', N'Hassan Plaza, 53 Karwan Bazar C/A, Dhaka 1215, Bangladesh. - See more at: http://www.jagobd.com/atnnews.html#sthash.6iruph6L.dpuf', N'www.samsung.com', 25000.0000, CAST(0x0000A46E00000000 AS DateTime), CAST(0x0000A46F00000000 AS DateTime), 1, CAST(0x0000A489010E2507 AS DateTime), 1, CAST(0x0000A48A00EF58B6 AS DateTime), 0)
INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'company Logo', N'Online shopping', 1, N'~/All Photos/Logo/20150430111436986043553325325.jpg', N'01755677765', N'kuril,badda,dhaka,bangladesh', N'www.oiiointernational.com', 456.0000, CAST(0x0000A47B00000000 AS DateTime), CAST(0x0000A48400000000 AS DateTime), 1, CAST(0x0000A489011030FA AS DateTime), 1, CAST(0x0000A496010392B2 AS DateTime), 0)
INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'7', N'7', 1, N'~/All Photos/Logo/20150429170407094528553325325.jpg', N'1', N'1', N'1', 1.0000, CAST(0x0000A46D00000000 AS DateTime), CAST(0x0000A46E00000000 AS DateTime), 1, CAST(0x0000A4890111DFFB AS DateTime), 1, CAST(0x0000A48901194884 AS DateTime), 1)
INSERT [dbo].[AdLogInfo] ([IID], [Name], [BussinessDescription], [DisplayOnPageID], [LogoUrl], [ContactPhoneNo], [Address], [WebAddress], [PayAmount], [DisplayStartDate], [DisplayEndDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'8', N'7', 1, N'~/All Photos/Logo/20150429170325439223553325325.jpg', N'1', N'1', N'1', 1.0000, CAST(0x0000A46D00000000 AS DateTime), CAST(0x0000A46E00000000 AS DateTime), 1, CAST(0x0000A48901184478 AS DateTime), 1, CAST(0x0000A489011917CB AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AdLogInfo] OFF
SET IDENTITY_INSERT [dbo].[AllFeature] ON 

INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, N'Compare gas prices and compare electricity prices', N'Energy Floors (a registered trade mark of Sustainable Dance Club™) successfully launched the world’s first energy generating floor, the Sustainable Dance Floor. If we can make the world a better place while having a good time, who wouldn’t want to join? Combining a creative approach with innovative technologies, Energy Floors is enabling clubs, festivals and events all over the world to become more sustainable and inventive. By launching the newest product: The Sustainable Energy Floor which is designed for fixed installations in high footfall areas, it is a first step of entering new target markets such as public transport, architecture, exhibitions.', N'~/All Photos/AllFeature/20150511135941952809553325325.JPG', 24, CAST(0x0000A49800BC93BA AS DateTime), 24, CAST(0x0000A49800BD598F AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, 2, N'Compare electricity prices and cut your costs', N'For the best prices for your energy, compare gas and electric prices in your area so you can choose the best electricity rates and switch online. All you need to compare electricity rates and find the best price, is your postcode and a recent energy bill. If you don''t have a bill at hand, we can estimate your usage based on the size of your home and how many people you live with. Then simply answer a few easy questions about your current supplier and electricity rates and what you want from your new supplier. You''ll soon be cutting down your household''s cost of electricity.', N'~/All Photos/AllFeature/20150510114222080515553325325.jpg', 24, CAST(0x0000A49500E5BA0E AS DateTime), 24, CAST(0x0000A49500E64C1F AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 2, 1, N'Anti-Money Laundering Compliance Specialist', N'Job Bank provides detailed information based on the 2006 version of the National Occupational Classification (NOC). The NOC is Canada''s national system to classify and describe all occupations across the country.', N'~/All Photos/AllFeature/20553325325.jpg', 24, CAST(0x0000A49500D222EE AS DateTime), 24, CAST(0x0000A49500D30A10 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 4, 1, N'Bussiness Insurance', N'While your day-to-day operations are complex, understanding Business insurance doesn''t have to be. There are coverage options available to protect just about every aspect of your business from employee injury to natural disasters. Some insurance is required by law and others by business associates, such as lenders and landlords. Obtaining the right type and amount of insurance for your business will help you avoid gaps in coverage where you need it most.', N'~/All Photos/AllFeature/20150511094719475691553325325.jpg', 24, CAST(0x0000A49500A0D041 AS DateTime), 24, CAST(0x0000A49500A15064 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 4, 2, N'How does life insurance work?', N'Life policies are legal contracts and the terms of the contract describe the limitations of the insured events. Specific exclusions are often written into the contract to limit the liability of the insurer; common examples are claims relating to suicide, fraud, war, riot, and civil commotion.', N'~/All Photos/AllFeature/20150510114715076153553325325.JPG', 24, CAST(0x0000A49400C1B89B AS DateTime), NULL, NULL, 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 4, 3, N'Car insurance means:', N'Tesco Bank Car Insurance gives you peace of mind, whether you''re off to the local supermarket or further afield. And when you buy direct, you get added security, with Motor Legal Protection included as standard.', N'~/All Photos/AllFeature/20150510120832312681553325325.JPG', 24, CAST(0x0000A49400C79151 AS DateTime), 24, CAST(0x0000A49400C81964 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 4, 4, N'Why home Insurance is a Smart Choice', N'If you''re trying to find a cheap quote on your house insurance, MoneySupermarket is here to help. We''ve compiled a range of guides so you can navigate your way through the various different types of home cover on offer to find the cheapest quote on your buildings and contents insurance - and to ensure you find a policy that''s right for you.', N'~/All Photos/AllFeature/20150510141527026287553325325.JPG', 24, CAST(0x0000A49400EA74B3 AS DateTime), 24, CAST(0x0000A49400EAF4E7 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 2, 2, N'Compare credit card offers from our partners', N'A credit card is a payment card issued to users as a system of payment. It allows the cardholder to pay for goods and services based on the holder''s promise to pay for them.[1] The issuer of the card creates a revolving account and grants a line of credit to the consumer (or the user) from which the user can borrow money for payment to a merchant or as a cash advance to the user. A credit card is different from a charge card: a charge card requires the balance to be paid in full each month.[2] In contrast, credit cards allow the consumers a continuing balance of debt, subject to interest being charged. A credit card also differs from a cash card, which can be used like currency by the owner of the card. A credit card differs from a charge card also in that a credit card typically involves a third-party entity that pays the seller and is reimbursed by the buyer, whereas a charge card simply defers payment by the buyer until a later date.', N'~/All Photos/AllFeature/20150511144813921663553325325.JPG', 24, CAST(0x0000A495002DB400 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 3, 1, N'Dubai Holidays', N'Miles of stunning coastline, the beautiful Arabian Desert, and year-round sunshine make Dubai the destination. While you’re there, be sure to shop ‘til you drop in the world’s largest shopping mall, barter in the some of city’s colorful local markets, and visit the famous man-made Palm Islands.', N'~/All Photos/AllFeature/20150511145419416808553325325.jpg', 24, CAST(0x0000A49500F521F1 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 7, 1, N'Broadband Provider', N'For Small and medium enterprises Grameenphone offers a unique package Ekota. Simplicity and Innovativeness are the unique features of the product. Users of this package can Stay Close to their clients, employees and business contacts through its wide range of features and services.', N'~/All Photos/AllFeature/20150511150424548628553325325.jpg', 24, CAST(0x0000A495003225E4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 1, 0, N'For Office', N'Dummy', N'~/All Photos/AllFeature/20150528121424551316553325325.jpg', 24, CAST(0x0000A4A600C8D450 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 1, 0, N'For Office', N'Tested', N'~/All Photos/AllFeature/20150528121626432090553325325.jpg', 24, CAST(0x0000A4A600C96322 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[AllFeature] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 1, 4, N'Why home Insurance is a Smart Choice', N'tested', N'~/All Photos/AllFeature/20150528121919177198553325325.JPG', 24, CAST(0x0000A4A600CA2D92 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[AllFeature] OFF
SET IDENTITY_INSERT [dbo].[AllFeatureDetail] ON 

INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'How to compare gas plans', N'Compare energy prices with the Telegraph energy comparison service provided by Energy Helpline to find your cheapest gas and electricity tariffs. Get a quote for your postcode and switch online in minutes', N'~/All Photos/AllFeatureDetails/20150510113922605018553325325.jpg', 24, CAST(0x0000A49400BF8E48 AS DateTime), 24, CAST(0x0000A49800BD59BA AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, N'How to compare  gas energy', N'Energy Floors (a registered trade mark of Sustainable Dance Club™) successfully launched the world’s first energy generating floor, the Sustainable Dance Floor. If we can make the world a better place while having a good time, who wouldn’t want to join? Combining a creative approach with innovative technologies, Energy Floors is enabling clubs, festivals and events all over the world to become more sustainable and inventive. By launching the newest product: The Sustainable Energy Floor which is designed for fixed installations in high footfall areas, it is a first step of entering new target markets such as public transport, architecture, exhibitions.', N'~/All Photos/AllFeatureDetails/20150511094148893587553325325.JPG', 24, CAST(0x0000A495009F5117 AS DateTime), 24, CAST(0x0000A49800BD59C1 AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, N'World Bank of Bangladesh', N'Job Bank provides detailed information based on the 2006 version of the National Occupational Classification (NOC). The NOC is Canada''s national system to classify and describe all occupations across the country.', N'~/All Photos/AllFeatureDetails/20150511094303274937553325325.jpg', 24, CAST(0x0000A495009FAC34 AS DateTime), 24, CAST(0x0000A49500D314AA AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 2, N'Need assistance? Read our home insurance guides', N'While your day-to-day operations are complex, understanding Business insurance doesn''t have to be. There are coverage options available to protect just about every aspect of your business from employee injury to natural disasters. Some insurance is required by law and others by business associates, such as lenders and landlords. Obtaining the right type and amount of insurance for your business will help you avoid gaps in coverage where you need it most.', N'~/All Photos/AllFeatureDetails/20150511094501020670553325325.jpg', 24, CAST(0x0000A49500A03E1C AS DateTime), 24, CAST(0x0000A49500A150AD AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 4, N'How Bussiness Insurance', N'While your day-to-day operations are complex, understanding Business insurance doesn''t have to be. There are coverage options available to protect just about every aspect of your business from employee injury to natural disasters. Some insurance is required by law and others by business associates, such as lenders and landlords. Obtaining the right type and amount of insurance for your business will help you avoid gaps in coverage where you need it most.', N'~/All Photos/AllFeatureDetails/20150511094628730475553325325', 24, CAST(0x0000A49500A0D0DF AS DateTime), NULL, NULL, 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 1, N'Compare gas energy', N'Energy Floors (a registered trade mark of Sustainable Dance Club™) successfully launched the world’s first energy generating floor, the Sustainable Dance Floor. If we can make the world a better place while having a good time, who wouldn’t want to join? Combining a creative approach with innovative technologies, Energy Floors is enabling clubs, festivals and events all over the world to become more sustainable and inventive. By launching the newest product: The Sustainable Energy Floor which is designed for fixed installations in high footfall areas, it is a first step of entering new target markets such as public transport, architecture, exhibitions.', N'~/All Photos/AllFeatureDetails/20150511140207846764553325325', 24, CAST(0x0000A49500E788A0 AS DateTime), 24, CAST(0x0000A49500E8CBC4 AS DateTime), 1)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 1, N'Compare gas energy', N'successfully launched the world’s first energy generating floor,', N'~/All Photos/AllFeatureDetails/20150511141750151664553325325.JPG', 24, CAST(0x0000A49500EB36D7 AS DateTime), 24, CAST(0x0000A49800BD59C9 AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 8, N'World Bank of Bangladesh', N'Job Bank provides detailed information based on the 2006 version of the National Occupational Classification (NOC). The NOC is Canada''s national system to classify and describe all occupations across the country.', N'~/All Photos/AllFeatureDetails/20150511094303274937553325325.jpg', 24, CAST(0x0000A495009FAC2C AS DateTime), 24, CAST(0x0000A49500D31454 AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 10, N'Ekota', N'For Small and medium enterprises Grameenphone offers a unique package Ekota. Simplicity and Innovativeness are the unique features of the product. Users of this package can Stay Close to their clients, employees and business contacts through its wide range of features and services.', N'~/All Photos/AllFeatureDetails/20150511150408769459553325325.jpg', 24, CAST(0x0000A49500321324 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllFeatureDetail] ([IID], [AllFeatureID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 1, N'How to compare', N'compare', N'~/All Photos/AllFeatureDetails/20150514112908360908553325325.jpg', 24, CAST(0x0000A49800BC9404 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[AllFeatureDetail] OFF
SET IDENTITY_INSERT [dbo].[AllNews] ON 

INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 4, N'Energy bills: prepay meters can cost poorer households hundreds', N'Millions of mostly poor UK households are paying up to £300 a year more than customers on the cheapest fuel tariffs, with thousands barred from switching to better deals.', N'~/All Photos/NewsImage/AllNews/1.jpg', CAST(0x0000A48A00F8A714 AS DateTime), 24, CAST(0x0000A48A00BC8D13 AS DateTime), 24, CAST(0x0000A48A00F8A722 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, 4, N'Energy bills: prepay meters can cost poorer households hundreds', N'How much extra prepayment customers pay depends on which expert you ask. Comparison site Confused.com puts the figure as high as £300 a year, Moneysupermarket just over £200 and uSwitch at about £163.

But it''s not just bigger bills prepayment customers face; there are plenty of other downsides. For starters, if you run out of energy unexpectedly, your supply will be switched off until you press the emergency credit button which gives you time to pop out and top up the card or key.', N'~/All Photos/NewsImage/AllNews/2.jpg', CAST(0x0000A4910119DB8D AS DateTime), 24, CAST(0x0000A48A00BCBF75 AS DateTime), 24, CAST(0x0000A4910119DB9B AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, 1, N'The most unusual day trip in the world', N'On the anniversary of the Chernobyl disaster, Bernice Davison recounts a trip to the site she made almost a decade ago', N'~/All Photos/NewsImage/AllNews/3.jpg', CAST(0x0000A49101092EB5 AS DateTime), 24, CAST(0x0000A48A00BC5D7C AS DateTime), 24, CAST(0x0000A49101092EC8 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 3, 1, N'Venezuela rations electricity as demand soars amid hot weather', N'gsfgsfg', N'~/All Photos/NewsImage/AllNews/4.jpg', CAST(0x0000A4A60115D391 AS DateTime), 24, CAST(0x0000A48900400CE0 AS DateTime), 24, CAST(0x0000A4A60115D3A3 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 4, 2, N'Energy bills: prepay meters can cost poorer households hundreds', N'asdfffffffffff', N'~/All Photos/NewsImage/AllNews/5.jpg', CAST(0x0000A48A00BC9749 AS DateTime), 24, CAST(0x0000A48A00BC974F AS DateTime), 24, CAST(0x0000A48A00BC9757 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 1, 3, N'Energy bills: prepay meters can cost poorer households hundreds', N'Nice connection', N'~/All Photos/NewsImage/AllNews/6.jpg', CAST(0x0000A48E00C65A84 AS DateTime), 24, CAST(0x0000A48E00C65A84 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 3, 3, N'Cheap Holets', N'This offering one of the best top ranking hotel.', N'~/All Photos/NewsImage/AllNews/7.jpg', CAST(0x0000A4A60115E940 AS DateTime), 21, CAST(0x0000A49100B69A18 AS DateTime), 24, CAST(0x0000A4A60115E94E AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 2, 2, N'Venezuela rations electricity as demand soars amid hot weather', N'No gas in bosundhara', N'~/All Photos/NewsImage/AllNews/8.jpg', CAST(0x0000A491011A5667 AS DateTime), 24, CAST(0x0000A49100548A30 AS DateTime), 24, CAST(0x0000A491011A5670 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 4, 1, N'Men are still charged more than women for car insurance, despite EU rule change', N'Male drivers pay more for car insurance than their female counterparts – despite strict gender equality laws – due to a loophole that lets firms charge more based on a person''s job.
These are the findings of leading finance academic Stephen McDonald, an economist from Newcastle University.
He claims insurers are "indirectly" discriminating against men by basing premiums on a person''s occupation.
He looked across six professions, two male dominated (civil engineers and plasterers), two female-dominated (dental nurses and social workers) and two gender neutral (solicitors and leisure assistants), collecting insurance price data from Confused.com, the comparison website.
In the majority of cases, drivers in their 20s, 30s and 40s paid cheaper premiums if they had a female-dominated job and more for the male-dominated industries.
Civil engineers, for example, pay 13pc above average, while the mostly female profession of dental nursing attracts premiums that are 10pc below average.
The onl', N'~/All Photos/NewsImage/AllNews/9.jpg', CAST(0x0000A49500C45108 AS DateTime), 21, CAST(0x0000A49500C45108 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 4, 1, N'Want help with treatment costs? Get a health cash plan', N'Health cash plans help towards NHS or private medical care and are designed to assist with the cost of treatment.

I have had a policy with BHSF for several years, which costs £11.25 a month (or £135 a year). In 2014 alone I received back £332.90 in claims, mostly because I needed some custom-made orthotics to correct a foot problem. Other claims were for dental check-ups and a trip to the physiotherapist.

I used to be short-sighted and claim back £100 a year for contact lenses, but laser eye surgery a couple of years ago means I don’t need contacts or glasses anymore. But even so, a health cash plan is still well worth it.

Brett Hill, director of the Health Insurance Group, explains how such a plan works: “In return for a monthly premium you can reclaim the cost of routine treatments, consultations or diagnostic tests, up to the limit of your chosen policy. You just need to arrange the treatment and pay the provider, then send off a receipt and claim form to your plan provider to r', N'~/All Photos/NewsImage/AllNews/10.jpg', CAST(0x0000A49500C4E834 AS DateTime), 21, CAST(0x0000A49500C4E834 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 4, 1, N'How do companies calculate car insurance premium', N'At any given point, your car has some value associated with it. If you suffer a total loss in an accident, how much do you think you should be compensated for, assuming you had insurance for your car? The amount that you are compensated for under a comprehensive motor insurance coverage is directly linked to what is the value of the vehicle at that point in time.

If you have a new car that you have just driven out of a showroom, its value is more than say a three-year-old car with 30,000 km on it. Insured declared value, or IDV, is the value that the insurance company places on your vehicle to estimate its worth at the time you apply for motor insurance.

Motor insurance policies are indemnity policies. That''s just a technical way of saying that they just compensate you for an amount up to financial loss that you have suffered on the vehicle, and no more.

IDV is the maximum amount that you can claim under a motor insurance policy to compensate for any loss arising from theft or acci', N'~/All Photos/NewsImage/AllNews/11.jpg', CAST(0x0000A49500C536B8 AS DateTime), 21, CAST(0x0000A49500C536B8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 4, 1, N'How Wearable Devices Could Disrupt the Insurance Industry', N'Nearly 50 years after Captain Kirk began using his wrist communicator on the television show, Star Trek, wearable technology is taking hold. From Fitbit and Nike Fuelbands to Google Glass and Golden-I, the technology is influencing how people live and work.

While there are many benefits to utilizing wearable technology in the insurance industry, along with the innovation comes risks, according to experts.', N'~/All Photos/NewsImage/AllNews/12.jpg', CAST(0x0000A49500C582E4 AS DateTime), 21, CAST(0x0000A49500C582E4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 6, 1, N'New Arrival', N'This is Mobile phone information deals', N'~/All Photos/NewsImage/AllNews/13.jpg', CAST(0x0000A4A6003EA774 AS DateTime), 21, CAST(0x0000A4A6003EA774 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 6, 3, N'Hurry and Collect', N'This is first time for bd', N'~/All Photos/NewsImage/AllNews/14.jpg', CAST(0x0000A4A6003EE20C AS DateTime), 21, CAST(0x0000A4A6003EE20C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (15, 6, 2, N'Get extra offer', N'Extra facility for bd clients', N'~/All Photos/NewsImage/AllNews/15.jpg', CAST(0x0000A4A6003F38C4 AS DateTime), 21, CAST(0x0000A4A6003F38C4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (16, 9, -1, N'News and community', N'Full he none no side. Uncommonly surrounded considered for him are its. It we is read good soon', N'~/All Photos/NewsImage/AllNews/16.jpg', CAST(0x0000A4A601131D3D AS DateTime), 24, CAST(0x0000A4A6004A45AC AS DateTime), 24, CAST(0x0000A4A601131D48 AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 9, -1, N'Strongly thoughts remember mr to do consider debating', N'Strongly thoughts remember mr to do cons', N'~/All Photos/NewsImage/AllNews/17.jpg', CAST(0x0000A4A60111647F AS DateTime), 24, CAST(0x0000A4A6004AEE6C AS DateTime), 24, CAST(0x0000A4A60111648F AS DateTime), 0)
INSERT [dbo].[AllNews] ([IID], [BusinessTypeID], [BusinessTypeBreakdownID], [TitleName], [Description], [ImageUrl], [ReleaseDate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (18, 3, 2, N'XmlTest', N'nice', N'', CAST(0x0000A4B700D73DC3 AS DateTime), 24, CAST(0x0000A4B700D73DCA AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[AllNews] OFF
SET IDENTITY_INSERT [dbo].[AllNewsDetail] ON 

INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'People on standard meters have a choice of online, fixed, green, dual fuel and discounted tariffs, as well as often receiving a discount for paying by direct debit.', N'But energy firms tend to offer just one tariff to prepayment customers, and it is usually much more expensive than the best buys.

How much extra prepayment customers pay depends on which expert you ask. Comparison site Confused.com puts the figure as high as £300 a year, Moneysupermarket just over £200 and uSwitch at about £163.', N'~/Images/NewsImage/AllNewsDetails/20150427134315856704553325325.jpg', 24, CAST(0x0000A487001BD17C AS DateTime), 1, CAST(0x0000A48A00B8AC87 AS DateTime), 1)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 2, N'People on standard meters have a choice of online, fixed, green, dual fuel and discounted tariffs, as well as often receiving a discount for paying by direct debit.', N'Millions of mostly poor UK households are paying up to £300 a year more than customers on the cheapest fuel tariffs, with thousands barred from switching to better deals.', N'', 24, CAST(0x0000A487001D3B98 AS DateTime), 24, CAST(0x0000A48700E5C6AA AS DateTime), 1)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, N'London Marathon: a guide for spectators', N'Only two thirds of parents who booked flights before changes to Air Passenger Duty were announced will try to claim back APD for children under 12, a survey has suggested.
Families with two young children will save £26 on a flight to Europe and £142 on flights departing after May 1.
But the method of claiming of these refunds varies drastically between airlines and one in three parents have said that they will not claim, no matter how large the amount they are claiming for is, according to research by money.co.uk. .
Some airlines, such as British Airways, Thomson and First Choice, are being proactive and offering refunds automatically, however others are asking consumers to apply for the refund themselves.
One of the reasons some parents aren’t claiming is they simply don’t know if they’ve been charged APD.', N'~/Images/NewsImage/AllNewsDetails/20150427135346559113553325325.jpg', 24, CAST(0x0000A487001EB4F0 AS DateTime), 1, CAST(0x0000A48A00B8944E AS DateTime), 1)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 5, N'People on standard meters have a choice of online, fixed, green, dual fuel and discounted tariffs, as well as often receiving a discount for paying by direct debit. ', N'456789', N'~/All Photos/NewsImage/AllNewsDetailsTemp/20150430111323201091553325325.jpg', 1, CAST(0x0000A48A00B8FAAF AS DateTime), 24, CAST(0x0000A48A00BC976E AS DateTime), 0)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 7, N'Great News for cheap hotels', N'Cheap hotels are not excellent generally.But Our offer includes best hotel facility..', N'~/All Photos/NewsImage/AllNewsDetails/20150507105837574404553325325.jpg', 21, CAST(0x0000A49100B5AC34 AS DateTime), 24, CAST(0x0000A4A60115E978 AS DateTime), 0)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 3, N'UUU kkkk', N'People on standard meters have a choice of online, fixed, green, dual fuel and discounted tariffs, as well as often receiving a discount for paying by direct debit. ', N'~/All Photos/NewsImage/AllNewsDetailsTemp/20150507154905848324553325325.jpg', 24, CAST(0x0000A4910104B749 AS DateTime), 24, CAST(0x0000A49101092EDE AS DateTime), 1)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 2, N'UUU', N'How much extra prepayment customers pay depends on which expert you ask. Comparison site Confused.com puts the figure as high as £300 a year, Moneysupermarket just over £200 and uSwitch at about £163.

But it''s not just bigger bills prepayment customers face; there are plenty of other downsides. For starters, if you run out of energy unexpectedly, your supply will be switched off until you press the emergency credit button which gives you time to pop out and top up the card or key.', N'~/All Photos/NewsImage/AllNewsDetailsTemp/20150507170603401285553325325.jpg', 24, CAST(0x0000A4910119DBAF AS DateTime), NULL, NULL, 0)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 8, N'NO NO NO It''s a challenge', N'good job... well done', N'~/All Photos/NewsImage/AllNewsDetails/20150507170741125503553325325.jpg', 24, CAST(0x0000A49100548328 AS DateTime), 24, CAST(0x0000A491011A568F AS DateTime), 0)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 18, N'People on standard meters have a choice of online, fixed, green, dual fuel and discounted tariffs, as well as often receiving a discount for paying by direct debit.', N'asdfa', N'~/All Photos/NewsImage/AllNewsDetails/20150614130708504519553325325.png', 24, CAST(0x0000A4B700D72AD3 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[AllNewsDetail] ([IID], [AllNewsID], [TitleName], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 18, N'testchild 2', N'lol', N'', 24, CAST(0x0000A4B700D738CE AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[AllNewsDetail] OFF
SET IDENTITY_INSERT [dbo].[Applicant] ON 

INSERT [dbo].[Applicant] ([IID], [FirstName], [MiddleName], [LastName], [FullName], [FatherName], [MotherName], [DateOfBirth], [GenderID], [SmokingHistoryID], [ApplicationFor], [IPNumber], [Address], [EmailAddress], [PhoneNo], [HomePhoneNo], [ProfessionID], [WantMoreInfoID], [HaveAdditionalJob], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (21, N'Mahbubur', NULL, N'Rahaman', N'Mahbubur Rahaman', NULL, NULL, CAST(0x00007F1B00000000 AS DateTime), 1, NULL, 4, N'192.168.1.12', NULL, N'mahbub.apece@gmail.com', N'+8801719777198', NULL, NULL, 6, NULL, 0, CAST(0x0000A49B00EA0DE9 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Applicant] ([IID], [FirstName], [MiddleName], [LastName], [FullName], [FatherName], [MotherName], [DateOfBirth], [GenderID], [SmokingHistoryID], [ApplicationFor], [IPNumber], [Address], [EmailAddress], [PhoneNo], [HomePhoneNo], [ProfessionID], [WantMoreInfoID], [HaveAdditionalJob], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (22, N'rrr', NULL, N'rrwew', N'rrr rrwew', NULL, NULL, CAST(0x0000880600000000 AS DateTime), 1, NULL, 2, N'192.168.1.16', NULL, N'o@gmail.com', N'+555555', NULL, NULL, 3, NULL, 0, CAST(0x0000A49B010BE9C5 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Applicant] ([IID], [FirstName], [MiddleName], [LastName], [FullName], [FatherName], [MotherName], [DateOfBirth], [GenderID], [SmokingHistoryID], [ApplicationFor], [IPNumber], [Address], [EmailAddress], [PhoneNo], [HomePhoneNo], [ProfessionID], [WantMoreInfoID], [HaveAdditionalJob], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (23, N'Mahbubur', NULL, N'sadf', N'Mahbubur sadf', NULL, NULL, CAST(0x00008AF400000000 AS DateTime), 1, NULL, 2, N'192.168.1.15', NULL, N'mahbub.apece@gmail.com', N'+8801719777198', NULL, NULL, 6, NULL, 0, CAST(0x0000A4A300B8C7DD AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Applicant] ([IID], [FirstName], [MiddleName], [LastName], [FullName], [FatherName], [MotherName], [DateOfBirth], [GenderID], [SmokingHistoryID], [ApplicationFor], [IPNumber], [Address], [EmailAddress], [PhoneNo], [HomePhoneNo], [ProfessionID], [WantMoreInfoID], [HaveAdditionalJob], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (24, N'Mahbubur', NULL, N'Rahaman', N'Mahbubur Rahaman', NULL, NULL, CAST(0x0000A4A700000000 AS DateTime), 1, NULL, 2, N'192.168.1.15', NULL, N'mahbub.apece@gmail.com', N'+8801719777198', NULL, NULL, 1, NULL, 24, CAST(0x0000A4A300CA9D64 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Applicant] OFF
SET IDENTITY_INSERT [dbo].[BDChannelInfo] ON 

INSERT [dbo].[BDChannelInfo] ([IID], [SerialNo], [Name], [Note], [ContactPhone], [Address], [WebAddress], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'ATN', N'Reputed and Traditional', N'01811256895', N'Baridhara, Dhaka', N'www.atn-bangla.com', 1, CAST(0x0000A48700E104C5 AS DateTime), 1, CAST(0x0000A4A600F54178 AS DateTime), 0)
INSERT [dbo].[BDChannelInfo] ([IID], [SerialNo], [Name], [Note], [ContactPhone], [Address], [WebAddress], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 2, N'Bangla Vision', N'Going to do better', N'0195623598', N'Dhanmondi, Dhaka', N'www.bangla-vision.com', 1, CAST(0x0000A48700E1541F AS DateTime), 1, CAST(0x0000A4A600F5563E AS DateTime), 0)
INSERT [dbo].[BDChannelInfo] ([IID], [SerialNo], [Name], [Note], [ContactPhone], [Address], [WebAddress], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, N'Desh TV', N'Well reputed', N'01852646546', N'Dhanmondi, Dhaka', N'www.desh-tv.com', 1, CAST(0x0000A48A0101964C AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BDChannelInfo] OFF
SET IDENTITY_INSERT [dbo].[BIAmountRange] ON 

INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 5000.0000, 900000.0000, N'5000 to 900000', N'It''s a test', 24, CAST(0x0000A49500C4043F AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 2, 5000.0000, 20000.0000, N'5000 to 20000', NULL, 24, CAST(0x0000A49800F8D00A AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, 200.0000, 60000.0000, N'200 to 60000', NULL, 24, CAST(0x0000A49800F8DD63 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 4, 9000.0000, 120000.0000, N'9000 to 120000', NULL, 24, CAST(0x0000A49800F8EB8D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 5, 20000.0000, 900000.0000, N'20000.0000 to 900000', N'Test', 24, CAST(0x0000A49800F8FBD1 AS DateTime), 21, CAST(0x0000A4A500AC0641 AS DateTime), 0)
INSERT [dbo].[BIAmountRange] ([IID], [TypeID], [AmountStart], [AmountEnd], [AmountDetail], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 1, 5000.0000, 500000.0000, N'5000 to 500000', NULL, 24, CAST(0x0000A4A600C0EF06 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BIAmountRange] OFF
SET IDENTITY_INSERT [dbo].[BIBusinessAge] ON 

INSERT [dbo].[BIBusinessAge] ([IID], [AgeInterval], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'0-5 year', N'if age is above four then you can apply..', 24, CAST(0x0000A49500CC26F2 AS DateTime), 24, CAST(0x0000A49500D1E65A AS DateTime), 0)
INSERT [dbo].[BIBusinessAge] ([IID], [AgeInterval], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'0-10 year', NULL, 24, CAST(0x0000A49800F80D97 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[BIBusinessAge] ([IID], [AgeInterval], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'5-10 year', NULL, 24, CAST(0x0000A4A600C4AC38 AS DateTime), 24, CAST(0x0000A4A600C74136 AS DateTime), 0)
INSERT [dbo].[BIBusinessAge] ([IID], [AgeInterval], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'10-20 year', NULL, 24, CAST(0x0000A4A600C7614C AS DateTime), 24, CAST(0x0000A4A600C76EA5 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BIBusinessAge] OFF
SET IDENTITY_INSERT [dbo].[BICategory] ON 

INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'Cloth', N'nice', 24, CAST(0x0000A4950059EFD4 AS DateTime), 24, CAST(0x0000A496009D767F AS DateTime), 0)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'Shop', N'', 24, CAST(0x0000A496009EBAC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'Life', N'Life Insurance', 21, CAST(0x0000A4A500A18CA4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, N'Home', N'', 21, CAST(0x0000A4A500A1EB90 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, N'Any wealth', N'', 21, CAST(0x0000A4A500A21F20 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, N'Securtiy', N'', 21, CAST(0x0000A4A500A27128 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[BICategory] ([IID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, N'Grameennn', N'test 1', 21, CAST(0x0000A4A500A2BD54 AS DateTime), 21, CAST(0x0000A4A500AB5F90 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BICategory] OFF
SET IDENTITY_INSERT [dbo].[BICategoryDetail] ON 

INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 3, N'Shirt', N'', 24, CAST(0x0000A4950059EFD4 AS DateTime), 24, CAST(0x0000A4950123C738 AS DateTime), 1)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 3, N'T-Shirt', N'', 24, CAST(0x0000A4950059EFD4 AS DateTime), 24, CAST(0x0000A496009D7696 AS DateTime), 1)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 3, N'Shirt', N'', 0, CAST(0x0000A4950123DFF7 AS DateTime), 24, CAST(0x0000A496009D76AE AS DateTime), 0)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 3, N'lehenga', N'', 0, CAST(0x0000A496009D76B9 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 5, N'Child', N'For children', 21, CAST(0x0000A4A500A18CA4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 5, N'Adult', N'For adult', 21, CAST(0x0000A4A500A18CA4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 9, N'Grameen 1', N'', 21, CAST(0x0000A4A500A2BD54 AS DateTime), 21, CAST(0x0000A4A500AB0344 AS DateTime), 1)
INSERT [dbo].[BICategoryDetail] ([IID], [BICategoryID], [Name], [Note], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 9, N'Sub Category', N'Test', 0, CAST(0x0000A4A500AB038F AS DateTime), 21, CAST(0x0000A4A500AB6051 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BICategoryDetail] OFF
SET IDENTITY_INSERT [dbo].[BusinessInsuranceReceiver] ON 

INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 6, 6, 1, 150000.0000, 0, CAST(0x0000A4970060B508 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 18, 5, 1, 200000000.0000, 0, CAST(0x0000A498002C3D00 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 19, 6, 1, 150000.0000, 0, CAST(0x0000A49800356718 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 20, 6, 1, 5000.0000, 0, CAST(0x0000A4980038AF54 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 22, 6, 2, 20.0000, 0, CAST(0x0000A49B00462828 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 23, 6, 1, 150000.0000, 0, CAST(0x0000A4A300B8C7E8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiver] ([IID], [ApplicantID], [BICategoryDetailID], [BIBusinessAgeID], [YearWiseTurnoverAmt], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 24, 6, 1, 150000.0000, 24, CAST(0x0000A4A300CA9C5C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BusinessInsuranceReceiver] OFF
SET IDENTITY_INSERT [dbo].[BusinessInsuranceReceiverDetail] ON 

INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, 0, CAST(0x0000A4970060DE0C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, 1, 0, CAST(0x0000A4970060E2BC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 2, 1, 0, CAST(0x0000A498002C6280 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 3, 3, 0, CAST(0x0000A498003578AC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 3, 1, 0, CAST(0x0000A498003578AC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 3, 4, 0, CAST(0x0000A498003578AC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 3, 2, 0, CAST(0x0000A498003578AC AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 4, 3, 0, CAST(0x0000A4980038BE90 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 4, 1, 0, CAST(0x0000A4980038BE90 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 4, 2, 0, CAST(0x0000A4980038BE90 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 5, 3, 0, CAST(0x0000A49B00462CD8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 5, 1, 0, CAST(0x0000A49B00462CD8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 5, 4, 0, CAST(0x0000A49B00462CD8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 5, 5, 0, CAST(0x0000A49B00462CD8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (15, 5, 2, 0, CAST(0x0000A49B00462CD8 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (16, 6, 1, 0, CAST(0x0000A4A300B8CDC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 7, 3, 24, CAST(0x0000A4A300CAACC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (18, 7, 1, 24, CAST(0x0000A4A300CAACC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (19, 7, 4, 24, CAST(0x0000A4A300CAACC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (20, 7, 5, 24, CAST(0x0000A4A300CAACC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[BusinessInsuranceReceiverDetail] ([IID], [BusinessInsuranceReceiverID], [BIAmountRangeID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (21, 7, 2, 24, CAST(0x0000A4A300CAACC4 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[BusinessInsuranceReceiverDetail] OFF
SET IDENTITY_INSERT [dbo].[CarInsuranceParameter] ON 

INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, 1, 200, 4000, 1, 10, 50000.0000, 1000000.0000, 5, 9, 1, CAST(0x0000A487010B49F7 AS DateTime), 1, CAST(0x0000A49700BF8442 AS DateTime), 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, 1, 100, 8000, 2, 25, 80000.0000, 25000000.0000, 4, 12, 1, CAST(0x0000A487010B8B7F AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 2, 2, 30, 80000, 2, 13, 300000.0000, 500000.0000, 8, 25, 1, CAST(0x0000A487010BDCD3 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 3, 2, 5000, 20000, 2, 8, 5000.0000, 10000.0000, 12, 5, 1, CAST(0x0000A494010B5C0C AS DateTime), 1, CAST(0x0000A49700BFA0DD AS DateTime), 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 4, 1, 200, 500, 0, 1, 50000.0000, 75000.0000, 5, 1, 1, CAST(0x0000A49700BE9C22 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 3, 3, 5000, 10000, 5, 10, 75000.0000, 150000.0000, 6, 3, 1, CAST(0x0000A49700BF1697 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 2, 2, 750, 1500, 1, 2, 450000.0000, 750000.0000, 8, 4, 1, CAST(0x0000A49700BF691C AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CarInsuranceParameter] ([IID], [CarTypeID], [CarConditionID], [MinRun], [MaxRun], [MinCarAge], [MaxCarAge], [MinCarValueAmount], [MaxCarValueAmount], [PremiumTotalPercent], [Duration], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 4, 3, 2000, 3500, 2, 5, 56000.0000, 90000.0000, 3, 3, 1, CAST(0x0000A49700BFAE70 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[CarInsuranceParameter] OFF
SET IDENTITY_INSERT [dbo].[CMSContent] ON 

INSERT [dbo].[CMSContent] ([IID], [CMSTypeID], [Title], [CMSDescription], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (3, 3, N'Made last it seen went no just when of by. Occasional entreaties comparison me difficulty so themselves.', N'<p>Merry alone do it burst me songs. Sorry equal charm joy her those folly ham. In they no is many both. Recommend new contented intention improving bed performed age. Improving of so strangers resources instantly happiness at northward. Danger nearer length oppose really add now either. But ask regret eat branch fat garden. Become am he except wishes. Past so at door we walk want such sang. Feeling colonel get her garrets own.&nbsp;</p>

<p>He my polite be object oh change. Consider no mr am overcame yourself throwing sociable children. Hastily her totally conduct may. My solid by stuff first smile fanny. Humoured how advanced mrs elegance sir who. Home sons when them dine do want to. Estimating themselves unsatiable imprudence an he at an. Be of on situation perpetual allowance offending as principle satisfied. Improved carriage securing are desirous too.&nbsp;</p>

<p>In to am attended desirous raptures declared diverted confined at. Collected instantly remaining up certainly to necessary as. Over walk dull into son boy door went new. At or happiness commanded daughters as. Is handsome an declared at received in extended vicinity subjects. Into miss on he over been late pain an. Only week bore boy what fat case left use. Match round scale now sex style far times. Your me past an much.&nbsp;</p>

<p>Do play they miss give so up. Words to up style of since world. We leaf to snug on no need. Way own uncommonly travelling now acceptance bed compliment solicitude. Dissimilar admiration so terminated no in contrasted it. Advantages entreaties mr he apartments do. Limits far yet turned highly repair parish talked six. Draw fond rank form nor the day eat.&nbsp;</p>

<p>Parish so enable innate in formed missed. Hand two was eat busy fail. Stand smart grave would in so. Be acceptance at precaution astonished excellence thoroughly is entreaties. Who decisively attachment has dispatched. Fruit defer in party me built under first. Forbade him but savings sending ham general. So play do in near park that pain.&nbsp;</p>

<p>Feet evil to hold long he open knew an no. Apartments occasional boisterous as solicitude to introduced. Or fifteen covered we enjoyed demesne is in prepare. In stimulated my everything it literature. Greatly explain attempt perhaps in feeling he. House men taste bed not drawn joy. Through enquire however do equally herself at. Greatly way old may you present improve. Wishing the feeling village him musical.&nbsp;</p>

<p>Made last it seen went no just when of by. Occasional entreaties comparison me difficulty so themselves. At brother inquiry of offices without do my service. As particular to companions at sentiments. Weather however luckily enquire so certain do. Aware did stood was day under ask. Dearest affixed enquire on explain opinion he. Reached who the mrs joy offices pleased. Towards did colonel article any parties.&nbsp;</p>

<p>Still court no small think death so an wrote. Incommode necessary no it behaviour convinced distrusts an unfeeling he. Could death since do we hoped is in. Exquisite no my attention extensive. The determine conveying moonlight age. Avoid for see marry sorry child. Sitting so totally forbade hundred to.&nbsp;</p>

<p>An sincerity so extremity he additions. Her yet there truth merit. Mrs all projecting favourable now unpleasing. Son law garden chatty temper. Oh children provided to mr elegance marriage strongly. Off can admiration prosperous now devonshire diminution law.&nbsp;</p>

<p>Two exquisite objection delighted deficient yet its contained. Cordial because are account evident its subject but eat. Can properly followed learning prepared you doubtful yet him. Over many our good lady feet ask that. Expenses own moderate day fat trifling stronger sir domestic feelings. Itself at be answer always exeter up do. Though or my plenty uneasy do. Friendship so considered remarkably be to sentiments. Offered mention greater fifteen one promise because nor. Why denoting speaking fat indulged saw dwelling raillery.&nbsp;</p>', N'~/All Photos/CMSPhoto/20150506111929525004553325325.jpg', 1, CAST(0x0000A49000BA1D8A AS DateTime), 24, CAST(0x0000A4A600F9DBED AS DateTime), 1)
INSERT [dbo].[CMSContent] ([IID], [CMSTypeID], [Title], [CMSDescription], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (13, 1, N'. Hearing now saw perhaps minutes herself his. Of in', N'<p>Whole every miles as tiled at seven or. Wished he entire esteem mr oh by. Possible bed you pleasure civility boy elegance ham. He prevent request by if in pleased. Picture too and concern has was comfort. Ten difficult resembled eagerness nor. Same park bore on be. Warmth his law design say are person. Pronounce suspected in belonging conveying ye repulsive.&nbsp;</p>

<p>As it so contrasted oh estimating instrument. Size like body some one had. Are conduct viewing boy minutes warrant expense. Tolerably behaviour may admitting daughters offending her ask own. Praise effect wishes change way and any wanted. Lively use looked latter regard had. Do he it part more last in. Merits ye if mr narrow points. Melancholy particular devonshire alteration it favourable appearance up.&nbsp;</p>

<p>Cottage out enabled was entered greatly prevent message. No procured unlocked an likewise. Dear but what she been over gay felt body. Six principles advantages and use entreaties decisively. Eat met has dwelling unpacked see whatever followed. Court in of leave again as am. Greater sixteen to forming colonel no on be. So an advice hardly barton. He be turned sudden engage manner spirit.&nbsp;</p>

<p>On no twenty spring of in esteem spirit likely estate. Continue new you declared differed learning bringing honoured. At mean mind so upon they rent am walk. Shortly am waiting inhabit smiling he chiefly of in. Lain tore time gone him his dear sure. Fat decisively estimating affronting assistance not. Resolve pursuit regular so calling me. West he plan girl been my then up no.&nbsp;</p>

<p>Among going manor who did. Do ye is celebrated it sympathize considered. May ecstatic did surprise elegance the ignorant age. Own her miss cold last. It so numerous if he outlived disposal. How but sons mrs lady when. Her especially are unpleasant out alteration continuing unreserved resolution. Hence hopes noisy may china fully and. Am it regard stairs branch thirty length afford.&nbsp;</p>

<p>Up branch to easily missed by do. Admiration considered acceptance too led one melancholy expression. Are will took form the nor true. Winding enjoyed minuter her letters evident use eat colonel. He attacks observe mr cottage inquiry am examine gravity. Are dear but near left was. Year kept on over so as this of. She steepest doubtful betrayed formerly him. Active one called uneasy our seeing see cousin tastes its. Ye am it formed indeed agreed relied piqued.&nbsp;</p>

<p>Surprise steepest recurred landlord mr wandered amounted of. Continuing devonshire but considered its. Rose past oh shew roof is song neat. Do depend better praise do friend garden an wonder to. Intention age nay otherwise but breakfast. Around garden beyond to extent by.&nbsp;</p>

<p>Advice me cousin an spring of needed. Tell use paid law ever yet new. Meant to learn of vexed if style allow he there. Tiled man stand tears ten joy there terms any widen. Procuring continued suspicion its ten. Pursuit brother are had fifteen distant has. Early had add equal china quiet visit. Appear an manner as no limits either praise in. In in written on charmed justice is amiable farther besides. Law insensible middletons unsatiable for apartments boy delightful unreserved.&nbsp;</p>

<p>Not far stuff she think the jokes. Going as by do known noise he wrote round leave. Warmly put branch people narrow see. Winding its waiting yet parlors married own feeling. Marry fruit do spite jokes an times. Whether at it unknown warrant herself winding if. Him same none name sake had post love. An busy feel form hand am up help. Parties it brother amongst an fortune of. Twenty behind wicket why age now itself ten.&nbsp;</p>

<p>Rendered her for put improved concerns his. Ladies bed wisdom theirs mrs men months set. Everything so dispatched as it increasing pianoforte. Hearing now saw perhaps minutes herself his. Of instantly excellent therefore difficult he northward. Joy green but least marry rapid quiet but. Way devonshire introduced expression saw travelling affronting. Her and effects affixed pretend account ten natural. Need eat week even yet that. Incommode delighted he resolving sportsmen do in listening.&nbsp;</p>', N'~/All Photos/CMSPhoto/20150528151422096683553325325.jpg', 24, CAST(0x0000A4A600FAE672 AS DateTime), 24, CAST(0x0000A4A600FB1070 AS DateTime), 1)
INSERT [dbo].[CMSContent] ([IID], [CMSTypeID], [Title], [CMSDescription], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (14, 2, N'Use securing confined his shutters', N'<p>Full he none no side. Uncommonly surrounded considered for him are its. It we is read good soon. My to considered delightful invitation announcing of no decisively boisterous. Did add dashwoods deficient man concluded additions resources. Or landlord packages overcame distance smallest in recurred. Wrong maids or be asked no on enjoy. Household few sometimes out attending described. Lain just fact four of am meet high.&nbsp;</p>

<p>Are own design entire former get should. Advantages boisterous day excellence boy. Out between our two waiting wishing. Pursuit he he garrets greater towards amiable so placing. Nothing off how norland delight. Abode shy shade she hours forth its use. Up whole of fancy ye quiet do. Justice fortune no to is if winding morning forming.&nbsp;</p>

<p>He went such dare good mr fact. The small own seven saved man age no offer. Suspicion did mrs nor furniture smallness. Scale whole downs often leave not eat. An expression reasonably cultivated indulgence mr he surrounded instrument. Gentleman eat and consisted are pronounce distrusts.&nbsp;</p>

<p>Perceived end knowledge certainly day sweetness why cordially. Ask quick six seven offer see among. Handsome met debating sir dwelling age material. As style lived he worse dried. Offered related so visitor we private removed. Moderate do subjects to distance.&nbsp;</p>

<p>Extremity direction existence as dashwoods do up. Securing marianne led welcomed offended but offering six raptures. Conveying concluded newspaper rapturous oh at. Two indeed suffer saw beyond far former mrs remain. Occasional continuing possession we insensible an sentiments as is. Law but reasonably motionless principles she. Has six worse downs far blush rooms above stood.&nbsp;</p>

<p>Am increasing at contrasted in favourable he considered astonished. As if made held in an shot. By it enough to valley desire do. Mrs chief great maids these which are ham match she. Abode to tried do thing maids. Doubtful disposed returned rejoiced to dashwood is so up.&nbsp;</p>

<p>Greatest properly off ham exercise all. Unsatiable invitation its possession nor off. All difficulty estimating unreserved increasing the solicitude. Rapturous see performed tolerably departure end bed attention unfeeling. On unpleasing principles alteration of. Be at performed preferred determine collected. Him nay acuteness discourse listening estimable our law. Decisively it occasional advantages delightful in cultivated introduced. Like law mean form are sang loud lady put.&nbsp;</p>

<p>Silent sir say desire fat him letter. Whatever settling goodness too and honoured she building answered her. Strongly thoughts remember mr to do consider debating. Spirits musical behaved on we he farther letters. Repulsive he he as deficient newspaper dashwoods we. Discovered her his pianoforte insipidity entreaties. Began he at terms meant as fancy. Breakfast arranging he if furniture we described on. Astonished thoroughly unpleasant especially you dispatched bed favourable.&nbsp;</p>

<p>Unwilling sportsmen he in questions september therefore described so. Attacks may set few believe moments was. Reasonably how possession shy way introduced age inquietude. Missed he engage no exeter of. Still tried means we aware order among on. Eldest father can design tastes did joy settle. Roused future he ye an marked. Arose mr rapid in so vexed words. Gay welcome led add lasting chiefly say looking.&nbsp;</p>

<p>Use securing confined his shutters. Delightful as he it acceptance an solicitude discretion reasonably. Carriage we husbands advanced an perceive greatest. Totally dearest expense on demesne ye he. Curiosity excellent commanded in me. Unpleasing impression themselves to at assistance acceptance my or. On consider laughter civility offended oh.&nbsp;</p>', N'', 24, CAST(0x0000A4A600FC17DA AS DateTime), 24, CAST(0x0000A4A600FC54D7 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CMSContent] OFF
SET IDENTITY_INSERT [dbo].[CommunityNews] ON 

INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'Education', N'~\Images\Interfaces\news1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves es', N'Education:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x0000A4A600ACBADB AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), 24, CAST(0x0000A4A600AD9979 AS DateTime), 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 3, N'Sports', N'~\Images/Interfaces/sports1.jpg', N'', N'
Ban vs Pak 1st odi', N'Sports:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 4, N'Popular Guide', N'~/All Photos/CommunityNews/20150528103216656088__150406153036_1_540x360.jpg', N'', N'How to protect your garden against thieves', N'Guide:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x0000A4A600ACD20D AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), 24, CAST(0x0000A4A600ADB0A4 AS DateTime), 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 2, N'Recreation', N'~\Images\Interfaces\news1.jpg', N'', N'How to protect your garden against thieves', N'Recreation:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 1, N'Education', N'~\Images\Interfaces\news1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Education:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 1, N'Education', N'~\Images\Interfaces\news1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Education:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 2, N'Recreation', N'~\Images\products\icon25.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Recreation:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 2, N'Recreation', N'~\Images\products\icon25.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Recreation:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 4, N'Guide', N'~\Images\Interfaces\news1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Guide:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 4, N'Guide', N'~\Images\products\icon25.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Guide:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 3, N'Sports', N'~\Images/Interfaces/sports1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'
Ban vs Pak 1st odi', N'Sports:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 3, N'Sports', N'~\Images/Interfaces/sports2.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'
Ban vs Pak 1st odi', N'Sports:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 3, N'Sports', N'~\Images/Interfaces/sports1.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'
Ban vs Pak 1st odi', N'Sports:The sun has finally decided to make an appearance, so it''s time to spruce up the garden and dust down the barbecue', CAST(0x00009F9800000000 AS DateTime), 0, 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 2, N'Recreation', N'~/Images/CommunityNews/20150514174701943731System.Random__bannner15.png.png', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'ল্যাপটপ মেলা উপলক্ষ্যে এসারের বর্ণাঢ্য অফার', N'বিশ্বখ্যাত কম্পিউটার নির্মাতা এসার ব্র্যান্ডের বাংলাদেশ পরিবেশক এক্সিকিউটিভ টেকনোলজিস লিমিটেড ল্যাপটপ মেলা ২০১৫ উপলক্ষে নিয়ে এসেছে এক বর্ণাঢ্য আয়োজন।

মে মাসের ১৪ থেকে ১৬ তারিখ পর্যন্ত বঙ্গবন্ধু আন্তর্জাতিক সম্মেলন কেন্দ্রে অনুষ্ঠিতব্য এই মেলাতে এসার ব্র্যান্ডের নেটবুক, নোটবুক, আল্ট্রাবুক, ও ট্যাবলেট পিসি এর উপর থাকছে ১০,০০০ টাকা পর্যন্ত মূল্যছাড়। মেলা থেকে যেকোনো নেটবুক অথবা সেলেরন বা পেন্টিয়াম প্রসেসর সমৃদ্ধ ল্যাপটপ কিনলে ক্রেতা উপহার হিসেবে পাবেন একটি ৮জিবি পেন ড্রাইভ। আর ইন্টেল কোর আই প্রসেসর সমৃদ্ধ ল্যাপটপ কিনলে ক্রেতা উপহার হিসেবে পাবেন একটি ৮জিবি পেন ড্রাইভ এবং একটি ওয়ারলেস মাউস। এসার ব্র্যান্ডের যেকোনো এন্ড্রয়েড বা উইন্ডোস ট্যাবলেট কিনলে ক্রেতা উপহার হিসেবে পাবেন একটি ১৬জিবি মাইক্রো এসডি কার্ড। এছাড়াও যেকোনো এসার ব্র্যান্ডের পণ্যের সাথে ক্রেতা পাবেন একটি সুদৃশ্য পোলো টি-শার্ট। মেলার অতিরিক্ত আকর্ষণ হিসেবে যেকোনো এসার পণ্য ক্রয়ের সাথে ক্রেতা পাবেন একটি র‍্যাফেল ড্র কুপন, যার থেকে মেলা চলাকালীন প্রতিদিন একাধিক এসার ট্যাবলেট ও স্মার্টফোন জিতে নেয়ার সুযোগ থাকছে।

ল্যাপটপ মেলা ২০১৫ তে এসার এর এই বিশাল মূল্যছাড়, উপহার ও র‍্যাফেল ড্র এর সুযোগ ক্রেতাসাধারণ উপভোগ করতে পারবেন এসার এর প্যাভিলিয়ন ও মেলায় অংশগ্রহণকারী এসার রিসেলার স্টল থেকে।

ল্যাপটপ মেলা উপলক্ষে এক্সিকিউটিভ টেকনোলজিস এসার এর বেশ কিছু নতুন মডেলও মেলায় উন্মোচন করেছে। এর মধ্যে উল্লেখ্য এসার ওয়ান মডেলের কনভার্টিবেল ল্যাপটপ, যার স্ক্রীনটি কিবোর্ড থেকে আলাদা করে ট্যাবলেটের মত ব্যাবহার করা যায়। কোয়াড কোর ইন্টেল অ্যাটম প্রসেসর ও টাচস্ক্রীন সমৃদ্ধ এই বিশেষ মডেলটিতে ধারণক্ষমতা ৩২জিবি এসএসডি হলে আপনি কিবোর্ড ডকে লাগালেই আরও ৫০০জিবি ধারণক্ষমতা সংযুক্ত হয়ে যায়।

মেলায় আরও এসেছে ৫ম প্রজন্মের ইন্টেল কোর আই প্রসেসর সমৃদ্ধ এসার অ্যাস্পায়ার ভি নাইট্রো গেমিং ল্যাপটপ, যাতে আছে ৪জিবি এনভিডিয়া জিফর্োস জিটিএক্স ৮৬০এম গ্রাফিক্স কার্ড। ১৫.৬” পর্দার এই ল্যাপটপটির উপরের অংশ কার্বন ফাইবারের তৈরি এবং এর কিবোর্ডটি লাল আলোয় আলোকিত।', CAST(0x0000A49801244D4E AS DateTime), 0, 1, CAST(0x0000A49801244D93 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (18, 1, N'Education', N'~/All Photos/CommunityNews/20150526115907567076__news5.jpg', N'https://www.youtube.com/embed/_UfFY6PSVu0', N'How to protect your garden against thieves', N'Education:The sun has finally decided to make an appearance, so it''s time to spruce up the garden an,Education:The sun has finally decided to make an appearance, so it''s time to spruce up the garden an', CAST(0x0000A4A400C49AD2 AS DateTime), 0, 1, CAST(0x0000A4A400C4C30F AS DateTime), NULL, NULL, 0)
INSERT [dbo].[CommunityNews] ([IID], [NewsTypeID], [NewsType], [Image], [VideoLink], [HeadLine], [NewsDescription], [PublishDate], [IsOnlyVideo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (19, 1, N'Education', N'~/All Photos/CommunityNews/20150527105925803801__student.jpg', N'', N'Wake County’s high-poverty magnet schools attract fewer applicants', N'The Wake County school system is staying away from any policy that might ban selfies, but the district may go after student and staff websites and social media accounts that are considered too disruptive.

School board members had raised concerns in November when a proposed update to the district’s technology policy included wording that could have banned students from taking pictures of themselves and others in school without a teacher’s permission. That wording does not appear in the version backed by the school board’s policy committee on Tuesday.

School administrators said they wanted the policy’s wording to be more positive and have less of the “thou shalt not” language of the November version. The new version says students are to use technology in a way that is “ethical, respectful, academically honest, and supportive of student learning.”

“We really want to focus on what can be done, rather than what can’t be done, and talk about how student use should be done responsibly,” said Marlo Gaddis, Wake’s senior director of instructional technology and media services.

Board members were happier with the new wording.

“You can’t position yourself as being innovative by talking about what you can’t do,” said school board member Jim Martin, chair of the policy committee.

Administrators say district policy should be updated to reflect the way technology is used today, compared to practices when the wording was last revised in 2010. This includes acknowledging that students are allowed to bring their own smartphones, tablets and laptops for use in class.

The latest version of the policy closely mirrors wording suggested by the N.C. School Boards Association. The version with the contested wording about pictures had been developed by one of the board’s attorneys.

Administrators said they also took the School Boards Association’s wording: “The superintendent may use any means available to request the removal of personal websites that substantially disrupt the school environment or that utilize school system or individual school names, logos, or trademarks without permission.”

The policy also warns that students may be disciplined if their online behavior during non-school hours “has a direct and immediate effect on school safety or maintaining order and discipline in the schools.”

The policy would cover social media accounts, including Facebook and Twitter, maintained by staff as well as students.

Todd Wirt, Wake’s assistant superintendent for academics, said they wanted to be able to react in case they find something that is disruptive to student learning.

Also as part of the new policy, parents would need to give permission for their children to use school technology. Previously, consent was assumed unless the parent opted out.', CAST(0x0000A4A500B54859 AS DateTime), 0, 1, CAST(0x0000A4A500A98FFB AS DateTime), 1, CAST(0x0000A4A500B62ABA AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[CommunityNews] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, N'88', N'Bangladesh', N'+88', 1, CAST(0x0000A48700D43721 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, N'003', N'Pakistan', N'+325', 1, CAST(0x0000A46900F05A34 AS DateTime), 1, CAST(0x0000A47100F08455 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, N'002', N'India', N'+23', 1, CAST(0x0000A46900FB03DF AS DateTime), 1, CAST(0x0000A46C00D20403 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, N'004', N'London (UK)', N'+48', 1, CAST(0x0000A469010BE0A6 AS DateTime), 1, CAST(0x0000A47000AFCAE0 AS DateTime), 1)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, N'005', N'United States', N'+1', 1, CAST(0x0000A469010C7D10 AS DateTime), 1, CAST(0x0000A46B01210348 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (19, N'9721', N'Australia', N'+972', 1, CAST(0x0000A46B00F2EE45 AS DateTime), 1, CAST(0x0000A49600F197DC AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (20, N'009', N'Italy', N'+8895', 1, CAST(0x0000A46B012400E9 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (21, N'9999', N'hhdghdfh', N'985', 1, CAST(0x0000A46C010C88B2 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1002, N'101', N'india', N'230', 1, CAST(0x0000A47100F0352A AS DateTime), 1, CAST(0x0000A47100F0E27C AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1003, N'1111', N'sssss', N'+123', 1, CAST(0x0000A47400D0FBDB AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1004, N'1112', N'South Korea', N'+67', 1, CAST(0x0000A47400D2F000 AS DateTime), NULL, CAST(0x0000A47400000000 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1005, N'1113', N'Taiwan', N'+98', 1, CAST(0x0000A47B00000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1006, N'1114', N'Sweden', N'+87', 1, CAST(0x0000A47B00000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1007, N'1115', N'Switzerland', N'+53', 1, CAST(0x0000A47B00000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1008, N'', N'Nepal', N'', 1, CAST(0x0000A4780102E07B AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1009, N'4563', N'DenMark', N'+4563', 1, CAST(0x0000A4780103FFE5 AS DateTime), 1, CAST(0x0000A49600F1C593 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1010, N'0901', N'Chaina', N'09012', 1, CAST(0x0000A478010472E5 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1011, N'657', N'Sri Lanka', N'+657', 1, CAST(0x0000A4860115EACE AS DateTime), 1, CAST(0x0000A486011696F8 AS DateTime), 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1012, N'44', N'UK', N'+44', 1, CAST(0x0000A48700E9F52D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Country] ([IID], [Code], [Name], [ISDCode], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1013, N'088', N'Cyprus', N'120', 1, CAST(0x0000A48900F1E620 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[DivisionOrState] ON 

INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 1, N'+12', N'Dhaka', 1, CAST(0x00009F9800000000 AS DateTime), 1, CAST(0x0000A46B01060F8F AS DateTime), 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 1, N'555', N'Khulna', 1, CAST(0x00009F9800000000 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 1, N'008', N'Rajshahi', 1, CAST(0x0000A46B00CDA2B2 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 1, N'009', N'Chittagong', 1, CAST(0x0000A46B00D02362 AS DateTime), 1, CAST(0x0000A46B00F20856 AS DateTime), 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 1, N'010', N'Barishal', 1, CAST(0x0000A46B00F23C95 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 1, N'00100', N'Rangpur', 1, CAST(0x0000A46B00FC6A62 AS DateTime), 1, CAST(0x0000A46B01044C37 AS DateTime), 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 1, N'0011', N'Mymensing', 1, CAST(0x0000A46B01033D12 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 5, N'Us001', N'California', 1, CAST(0x0000A46B01047D51 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 5, N'Us002', N'New York', 1, CAST(0x0000A46B0104D7CF AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 5, N'Us003', N'Iowa', 1, CAST(0x0000A46B01057784 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 5, N'Us004', N'Texas', 1, CAST(0x0000A46B0105CE4D AS DateTime), NULL, NULL, 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 5, N'Us005', N'Washington', 1, CAST(0x0000A46B0106BD16 AS DateTime), 1, CAST(0x0000A46B0107029C AS DateTime), 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 19, N'00101', N'Aust State', 1, CAST(0x0000A46C00CCF51E AS DateTime), 1, CAST(0x0000A46C00CD355C AS DateTime), 1)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10002, 1008, N'NEP101', N'Khatmundu', 1, CAST(0x0000A48601173B69 AS DateTime), 1, CAST(0x0000A4860117D7C3 AS DateTime), 0)
INSERT [dbo].[DivisionOrState] ([IID], [CountryID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10003, 1004, N'NY', N'NYState', 1, CAST(0x0000A48900F21DEE AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[DivisionOrState] OFF
SET IDENTITY_INSERT [dbo].[GasDealerInfo] ON 

INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 10, N'1246163', N'Akbar Hossain khan', N'1246163', N'Badda', 1, 24, CAST(0x0000A4A600D87634 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 11, N'BBS Cables', N'Mahmudul Hasan', N'0177567496', N'Nikunja', 2, 1, CAST(0x0000A48700EA5C14 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 12, N'Fairbook outlets', N'Mehedi Hasan', N'45361252', N'Kolkata, India', 9, 1, CAST(0x0000A48700EA7795 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 1020, N'Building Materials', N'Shimul Bhowmick', N'2356124', N'Kuril, Dhaka', 3, 1, CAST(0x0000A48700EA8F3F AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 13, N'BBS Cables', N'Mahbubur Rahman', N'2356124', N'Badda', 2, 1, CAST(0x0000A48700EAB877 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 11, N'mjs', N'hehe', N'000', N'kuril', 10002, 24, CAST(0x0000A4A600D9A64E AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GasDealerInfo] ([IID], [CompanyInfoID], [TradeName], [DealerName], [PhoneNo], [Address], [DistrictID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 11, N'000', N'hehe bb', N'000', N'OiiO international', 10004, 24, CAST(0x0000A4A600DE153B AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[GasDealerInfo] OFF
SET IDENTITY_INSERT [dbo].[GuideLine] ON 

INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 6, N'Mobile phone reviews', N'If you''re looking for mobile phone information to guide you in your mobile choice or some help with a mobile problem, our mobile phone guides couldn''t be easier to use.', N'~/Images/banner/20150427151116148911553325325.jpg', 1, CAST(0x0000A48700348870 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 6, N'Mobile phone reviews', N'If you''re looking for mobile phone information to guide you in your mobile choice or some help with a mobile problem, our mobile phone guides couldn''t be easier to use.', N'~/Images/banner/20150427151116148911553325325.jpg', 1, CAST(0x0000A48700F9C357 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 1, N'Gas And Electricity Guides', N'Guide Line for Gas And Electricity Service Guide Line for Gas And Electricity Service', N'~/All Photos/Energy/Gas/Cyliender/5.jpg', 1, CAST(0x0000A487003BC400 AS DateTime), 1, CAST(0x0000A48A00BEF384 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 1, N'Gas And Electricity', N'Guide Line for Gas And Electricity Service', N'~/All Photos/Energy/Gas/Cyliender/5.jpg', 1, CAST(0x0000A4870100FED7 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 8, N'Broadband Guides', N'If you''re looking for broadband information to guide you in your broadband choice or some help with a broadband problem, our easy to follow broadband guides are here to help.  Broadband guides from uSwitch Broadband will explain everything you need to know in jargon-free terms, so from wireless routers to mobile broadband modems, you will become an instant broadband expert.', N'~/Images/banner/20150427154148620898553325325.jpg', 1, CAST(0x0000A487003CEC7C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 8, N'Broadband Guides', N'If you''re looking for broadband information to guide you in your broadband choice or some help with a broadband problem, our easy to follow broadband guides are here to help.  Broadband guides from uSwitch Broadband will explain everything you need to know in jargon-free terms, so from wireless routers to mobile broadband modems, you will become an instant broadband expert.', N'~/Images/banner/20150427154148620898553325325.jpg', 1, CAST(0x0000A487003CEC7C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 1)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 8, N'Broadband Guides', N'If you''re looking for broadband information to guide you in your broadband choice or some help with a broadband problem, our easy to follow broadband guides are here to help.  Broadband guides from uSwitch Broadband will explain everything you need to know in jargon-free terms, so from wireless routers to mobile broadband modems, you will become an instant broadband expert.', N'~/Images/banner/20150427154148620898553325325.jpg', 1, CAST(0x0000A48701035162 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 2, N'Credit card guides', N'Credit card guides description:', NULL, 1, CAST(0x0000A487003FBF88 AS DateTime), 1, CAST(0x0000A48A00BEC9AC AS DateTime), 1)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 3, N'Google delivers major Chrome for iOS update', N'Now, users of Chrome on an iPhone can swipe straight down to refresh a page, swipe down and left to open a tab or down and right to close one.  Chuck in support for password management tools such as 1Password and Lastpass, plus improved search bar smarts, including suggestions such as weather, stocks and copied URLs and you’re looking at the best browser for iOS bar none.  It all means that you only need reach up to the top of your iPhone’s screen if you want to tap in a new address or search term.  That should placate those who love the iPhone 6’s screen real estate, but aren’t so enamoured with not being able to use the device comfortably one-handed.  The update is available now via Google and the App Store.', N'~/All Photos/GuideLine/GuideLine/20150429173433586005553325325.jpg', 1, CAST(0x0000A489005B0464 AS DateTime), 1, CAST(0x0000A4890121A51D AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 6, N'Google Nexus 7 pulled from Play Store', N'ogle has pulled the Nexus 7 (2013) tablet from its Play Store, apparently killing off a device that was widely heralded as being every bit as good as Apple’s iPad mini at launch.  Those looking to buy the device over the weekend from Google’s web outlet were told that the Nexus 7 is "no longer available to purchase".  The Big G is said to be pouring all its efforts into the more capacious Nexus 9 tablet. There’s no word on whether it is planning on launching a new version of its 7-inch slate.  The Nexus 7 (2013) still receives the very latest Google Android software before almost any other compatible device, even if its hardware has struggled with the latest iteration.  With tablet sales stagnating (even Apple can’t convince new users to stump up for a new iPad), it’s unlikely Google will make a new version of the tablet in the near future.  Its well regarded Nexus 6 smartphone is only a tiny bit smaller and has much more to offer users in 2015 than its ageing stablemate.', N'~/All Photos/GuideLine/GuideLine/20150429173123507592553325325.jpg', 1, CAST(0x0000A48901204083 AS DateTime), 1, CAST(0x0000A48901227D6F AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 2, N'Credit card guides', N'Your personal finances are no different to your home, garden or garage – they need a spring clean from time to time.', N'~/All Photos/GuideLine/GuideLine/20150429175012362026553325325.jpeg', 1, CAST(0x0000A48900602F70 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 2, N'Credit card guides', N'Your personal finances are no different to your home, garden or garage – they need a spring clean from time to time.', N'~/All Photos/GuideLine/GuideLineDetail/20150430121338089824553325325.jpg', 1, CAST(0x0000A48901256B4F AS DateTime), 1, CAST(0x0000A48A00C97FE2 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (14, 4, N'Life insurance guides', N'You may see life insurance sometimes referred to as life assurance, but there is a small key difference between the two.  Life assurance does not cover a fixed term, but is designed to cover you for the rest of your life. As the name implies, death is assured, and thus the policy will cover you when you die. On the other hand, life insurance means that the policy can cover you in the event that you die during the length of the term i.e. term life insurance.  While you can compare life insurance on uSwitch, you can also check our advice guides for the facts on how to buy cheap life insurance, life assurance for over 50s, level term life insurance, and critical illness cover.', N'~/All Photos/GuideLine/GuideLine/20150429175438122240553325325.jpg', 1, CAST(0x0000A48900616728 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (15, 4, N'Life insurance guides', N'You may see life insurance sometimes referred to as life assurance, but there is a small key difference between the two.  Life assurance does not cover a fixed term, but is designed to cover you for the rest of your life. As the name implies, death is assured, and thus the policy will cover you when you die. On the other hand, life insurance means that the policy can cover you in the event that you die during the length of the term i.e. term life insurance.  While you can compare life insurance on uSwitch, you can also check our advice guides for the facts on how to buy cheap life insurance, life assurance for over 50s, level term life insurance, and critical illness cover.', N'~/All Photos/GuideLine/GuideLine/20150429175438122240553325325.jpg', 1, CAST(0x0000A4890126A2F8 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 5, N'Get a new boiler from British Gas', N'Choosing a new boiler or central heating system is an important decision, and one you''ll benefit from for many years to come. Here are our top reasons to choose British Gas:', N'~/All Photos/GuideLine/GuideLine/20150430111427092192553325325.jpg', 1, CAST(0x0000A48A00B93F70 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (18, 5, N'Get a new boiler from British Gas', N'Choosing a new boiler or central heating system is an important decision, and one you''ll benefit from for many years to come. Here are our top reasons to choose British Gas:', N'~/All Photos/GuideLine/GuideLine/20150430111427092192553325325.jpg', 1, CAST(0x0000A48A00B8B8F3 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GuideLine] ([IID], [BusinessTypeID], [Title], [Description], [ImageUrl], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (20, 9, N'jnik', N'kjnkj', N'~/All Photos/GuideLine/GuideLineDetail/20150504180824688580553325325.jpg', 1, CAST(0x0000A48E00652F20 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[GuideLine] OFF
SET IDENTITY_INSERT [dbo].[GuideLineDetail] ON 

INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 7, N'4G mobile broadband', N'~/Images/banner/20150427154036941490553325325.jpg', N'3G technology made high-speed mobile internet access possible for the first time.  Once upon a time, the connection speeds 3G offered were enough to provide basic data and voice services, but as handheld devices and mobiles have evolved so has demand for higher-quality media at better connection speeds.  The result was the development of super-fast 4G mobile broadband technology.', 1, CAST(0x0000A487003C981C AS DateTime), 1, CAST(0x0000A4A600D85FFD AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (13, 8, N'4G mobile broadband', N'~/Images/banner/20150427154036941490553325325.jpg', N'3G technology made high-speed mobile internet access possible for the first time.  Once upon a time, the connection speeds 3G offered were enough to provide basic data and voice services, but as handheld devices and mobiles have evolved so has demand for higher-quality media at better connection speeds.  The result was the development of super-fast 4G mobile broadband technology.', 1, CAST(0x0000A48701035172 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (16, 9, N'Prepaid cards – Find a prepaid card for travel', N'~/Images/banner/20150427155024919041553325325.jpg', N'The cards are normally issued by MasterCard, Maestro or Visa, and can be used wherever these payment methods are accepted.  They work by simply transferring money from your bank account or loading the card with cash at any Post Office or shop with PayPoint or Payzone facilities.  Some prepaid cards will allow you to top up with a credit or debit card online, giving them a reasonable level of flexibility.', 1, CAST(0x0000A487003F492C AS DateTime), 1, CAST(0x0000A48901188F36 AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (17, 7, N'Basic mobile phones', N'~/All Photos/GuideLine/GuideLineDetail/20150429163859174380553325325.jpg', N'you generally use your mobile phone for calls and texts only, and aren’t particularly worried about internet, cameras or maps, then you can take your pick when it comes to mobiles - your focus will only be on the kind of tariff you have.

Even when you pick the most basic mobile phones with only the key functions, you''ll still get a range of useful tools such as a diary, a calculator and an alarm clock.', 1, CAST(0x0000A489004C1A6C AS DateTime), 1, CAST(0x0000A48901137017 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (19, 11, N'Google Now partners with 70 new apps', NULL, N'ogle has revealed that 70 additional third party apps now work with its ace Google Now service. Big names such as Spotify, Zipcar, eBay and Shazam now all offer Google Now cards.', 1, CAST(0x0000A48901204093 AS DateTime), 1, CAST(0x0000A48901220691 AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (20, 10, N'Google Now partners with 70 new apps', NULL, N'ogle has revealed that 70 additional third party apps now work with its ace Google Now service. Big names such as Spotify, Zipcar, eBay and Shazam now all offer Google Now cards.', 1, CAST(0x0000A48901211F4C AS DateTime), 1, CAST(0x0000A4890121A51D AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (21, 11, N'Why use uSwitch', N'~/All Photos/GuideLine/GuideLineDetail/20150429174131258217553325325.jpg', N'No third party sites! Confirm your switch with us and we''ll even notify your new supplier. You just sit back and save!', 1, CAST(0x0000A4890121F795 AS DateTime), 1, CAST(0x0000A48901238E9A AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (22, 12, N'How to spring-clean your finances', N'~/All Photos/GuideLine/GuideLineDetail/20150429175000676430553325325.jpg', N'The words ‘cleaning’ and ‘finances’ don’t exactly scream fun, but checking on your finances is quicker and easier than you might think, and switching to some new deals could save you hundreds, even thousands a year.', 1, CAST(0x0000A4890060228C AS DateTime), 1, CAST(0x0000A48901267807 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (23, 13, N'How to spring-clean your finances', N'~/All Photos/GuideLine/GuideLineDetail/20150429175000676430553325325.jpg', N'The words ‘cleaning’ and ‘finances’ don’t exactly scream fun, but checking on your finances is quicker and easier than you might think, and switching to some new deals could save you hundreds, even thousands a year.', 1, CAST(0x0000A48901256B5F AS DateTime), NULL, NULL, 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (27, 17, N'4 reasons to get a new British Gas boiler:', N'~/All Photos/GuideLine/GuideLineDetail/20150430111404512522553325325.jpg', N'Buy a new boiler from British Gas and you’ll get 20% off the cost of a new boiler.† Know exactly what you’ll pay – you’ll get a fixed price quote so even if there’s unexpected work, you won''t pay a penny more. You''ll have one of the most energy-efficient boilers – British Gas installs the latest A-rated boilers so you could save as much as £305 a year on your energy bills*. Includes a year''s aftercare your boiler and central heating.', 1, CAST(0x0000A48A00B9247C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (28, 18, N'4 reasons to get a new British Gas boiler:', N'~/All Photos/GuideLine/GuideLineDetail/20150430111404512522553325325.jpg', N'Buy a new boiler from British Gas and you’ll get 20% off the cost of a new boiler.† Know exactly what you’ll pay – you’ll get a fixed price quote so even if there’s unexpected work, you won''t pay a penny more. You''ll have one of the most energy-efficient boilers – British Gas installs the latest A-rated boilers so you could save as much as £305 a year on your energy bills*. Includes a year''s aftercare your boiler and central heating.', 1, CAST(0x0000A48A00B8B918 AS DateTime), 1, CAST(0x0000A48A00B9F024 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (29, 9, N'How to compare credit cards', NULL, N'It’s important to decide whether the new card will be used for spending, transferring a balance, building up a credit rating or more.  There are many credit card types on the market, so if you already know the kind you’re looking for, use our credit card tables to see all the best deals.', 1, CAST(0x0000A48A00BE3F4F AS DateTime), 1, CAST(0x0000A48A00BEC9AC AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (30, 9, N'Prepaid cards – Find a prepaid card for travel', NULL, N'The cards are normally issued by MasterCard, Maestro or Visa, and can be used wherever these payment methods are accepted.  They work by simply transferring money from your bank account or loading the card with cash at any Post Office or shop with PayPoint or Payzone facilities.  Some prepaid cards will allow you to top up with a credit or debit card online, giving them a reasonable level of flexibility.', 1, CAST(0x0000A48A00BE3F65 AS DateTime), 1, CAST(0x0000A48A00BEC9AC AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (31, 3, N'Which energy supplier has the best iPhone or Android app?', NULL, N'Few of us would put "managing my gas and electricity account" at the top of our list when it comes to finding smartphone apps to download.', 1, CAST(0x0000A48A00BE691F AS DateTime), 1, CAST(0x0000A48A00BEF384 AS DateTime), 1)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (33, 13, N'How to spring-clean your finances', NULL, N'The words ‘cleaning’ and ‘finances’ don’t exactly scream fun, but checking on your finances is quicker and easier than you might think, and switching to some new deals could save you hundreds, even thousands a year.', 1, CAST(0x0000A48A00C8F590 AS DateTime), 1, CAST(0x0000A48A00C97FE2 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (34, 20, N'jkijki', N'~/All Photos/GuideLine/GuideLineDetail/20150504180944512119553325325.jpg', N'jjjkijj', 1, CAST(0x0000A48E00651B34 AS DateTime), 1, CAST(0x0000A48E012B4EAE AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (35, 20, N'ughughu', N'~/All Photos/GuideLine/GuideLineDetail/20150504180815963026553325325', N'hguguhu', 1, CAST(0x0000A48E006525C0 AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (36, 11, N'Bengali Language', N'~/All Photos/GuideLine/GuideLineDetail/20150528113944575876553325325.jpg', N'Bengali Language', 24, CAST(0x0000A4A600BF679C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (37, 14, N'Basic mobile phones', N'~/All Photos/GuideLine/GuideLineDetail/20150528115106239829553325325.jpg', N'Basic mobile phones', 24, CAST(0x0000A4A600C2892C AS DateTime), 0, CAST(0x0000000000000000 AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (38, 11, N'Bengali Language', N'~/All Photos/GuideLine/GuideLineDetail/20150528122423652117553325325.jpg', N'Bengali Language', 24, CAST(0x0000A4A600CBA084 AS DateTime), 1, CAST(0x0000A4A600D099BE AS DateTime), 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (39, 3, N'Hello', N'~/All Photos/GuideLine/GuideLineDetail/20150528143809475812553325325.jpg', N'eeeeee', 24, CAST(0x0000A4A6002A9144 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[GuideLineDetail] ([IID], [GuideLineID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (40, 4, N'sdfgvsdfgs', N'~/All Photos/GuideLine/GuideLineDetail/20150528143826995623553325325.jpg', N'eee', 24, CAST(0x0000A4A6002AA530 AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[GuideLineDetail] OFF
SET IDENTITY_INSERT [dbo].[GuideLineDetailMore] ON 

INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (1, 17, N'Too much mobile choice? Help is at hand from our guide to choosing a mobile phone.', N'~/All Photos/GuideLine/Images/GuideLineDetailMore/20150429163719073836553325325.jpg', N'With so many handsets, networks and tariffs on the market, choosing a new mobile phone can be a daunting task.

At uSwitch, we think the best way to simplify the selection process is to think about how you use your phone and which mobile phone features you need most.', 1, CAST(0x0000A489004BA53C AS DateTime), 0, CAST(0x0000A4A600F4DD59 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (2, 17, N'Smartphones', N'~/All Photos/GuideLine/Images/GuideLineDetailMore/20150429163950013606553325325.jpg', N'Smartphones are a computer, personal organiser, digitial camera and MP3 player in one. And much, much more besides.

Powered by the Android, Windows Phone and iOS operating systems, the best smartphones often feature hefty price tags.

But mid-range and even cheaper smartphones are available.

These will feature a good proportion of the same features, but with smaller screens and less powerful cameras and processors than the top-of-the-range models.', 1, CAST(0x0000A48901122385 AS DateTime), 1, CAST(0x0000A4A600F4D7A1 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (3, 17, N'Business mobile phones', N'~/All Photos/GuideLine/GuideLineDetailMore/20150429164246737615553325325.jpg', N'For many people, choosing a mobile phone is a practical business decision and they''re looking for a phone to help them take care of work while they''re on the go.

Blackberry handsets have long been a favourite with business users. They offer full QWERTY keyboards, advanced email and messaging options, enterprise security and an on board office applications suite for working on the go.

But if all you don''t need that kind of advanced business functionality and just want a phone that lets you email clients, any smartphone will fit the bill.', 1, CAST(0x0000A4890112EA47 AS DateTime), 1, CAST(0x0000A48901137022 AS DateTime), 0)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (4, 16, N'Mobile phone deals', N'~/All Photos/GuideLine/GuideLineDetailMore/20150429170125775705553325325.jpg', N'Many manufacturers realise that users do not always fall into one category, and provide handsets and tariffs that encompass all the above features.

The next step in choosing a mobile phone is finding the perfect package from the right network provider.

You may want to choose a mobile phone package where you pay monthly for your minutes, texts and data allowances, or you may want to choose a pay as you go or SIM only mobile phone package.', 1, CAST(0x0000A4890118095F AS DateTime), 1, CAST(0x0000A48901188F36 AS DateTime), 0)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (5, 19, N'Google Name', N'~/All Photos/GuideLine/GuideLineDetailMore/20150429173553901135553325325.jpg', N'Now, users of Chrome on an iPhone can swipe straight down to refresh a page, swipe down and left to open a tab or down and right to close one.

Chuck in support for password management tools such as 1Password and Lastpass, plus improved search bar smarts, including suggestions such as weather, stocks and copied URLs and you’re looking at the best browser for iOS bar none.

It all means that you only need reach up to the top of your iPhone’s screen if you want to tap in a new address or search term.

That should placate those who love the iPhone 6’s screen real estate, but aren’t so enamoured with not being able to use the device comfortably one-handed.

The update is available now via Google and the App Store.', 1, CAST(0x0000A489012180BA AS DateTime), 1, CAST(0x0000A4A600F4D355 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (6, 21, N'Why choose EE', N'~/All Photos/GuideLine/GuideLineDetailMore/20150429174117112875553325325.jpg', N'Movies on the move with EE Film Club
EE Film Club lets you stream the latest movies on your smartphone, tablet or laptop from Wuaki.tv. Films are priced £1 each.', 1, CAST(0x0000A489012308C3 AS DateTime), 1, CAST(0x0000A4A600F4CEA5 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (7, 22, N'Clean up your credit cards', N'~/All Photos/GuideLine/GuideLineDetailMore/20150429175204259644553325325.jpg', N'If you think you’re paying too much but have a stubborn balance you can’t clear, there is no need to continue paying interest.

Transferring the balance to a specialist balance transfer card with an 0% introductory offer that will let you put off paying interest for as long as three years.

Make sure to work out whether it’s worth your time though, as the transfer fee may cost you more than you could save by avoiding interest charges.

Also don’t miss the minimum monthly repayments, or you may lose the 0% offer and be charged interest.

Finally remember the golden rule of balance transfer cards – you can only transfer your debt from a different provider, so from Barclaycard to Santander for example.

What you need – Your current credit card provider and balance you want to transfer. It’s also worth finding your APR on a statement to make sure you will be saving money.', 1, CAST(0x0000A4890125F22C AS DateTime), 1, CAST(0x0000A4A600F4CACD AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (8, 28, N'New boiler: What''s the cost of a new boiler?', N'~/All Photos/GuideLine/GuideLineDetailMore/20150430111652868688553325325.jpg', N'Your boiler may be the single most important item in your home, particularly around winter, so when it comes to maintaining your boiler or boiler replacement, it''s essential to make sure you get it right.

But when is the right time to replace your boiler, and what should you be looking for in a newer model?

Here we look at whether or not it''s worth replacing your old boiler and how long it will take for the investment to pay for itself.', 1, CAST(0x0000A48A00B96910 AS DateTime), 1, CAST(0x0000A4A600F46D76 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (9, 34, N'jknk', N'~/All Photos/GuideLine/GuideLineDetailMore/20150504180928096959553325325.jpg', N'jniujninm', 1, CAST(0x0000A48E012ACCFF AS DateTime), 1, CAST(0x0000A4A600F45D80 AS DateTime), 1)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (10, 38, N'Too much mobile choice?', N'~/All Photos/GuideLine/GuideLineDetailMore/20150528124201019919553325325.jpg', N'Help is at hand from our guide to choosing a mobile phone.', 1, CAST(0x0000A4A600D0F5A2 AS DateTime), 1, CAST(0x0000A4A600D1C31C AS DateTime), 0)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (11, 11, N'dfgfdg', N'~/All Photos/GuideLine/GuideLineDetailMore/20150528131037242800553325325.jpg', N'fdgdfg', 1, CAST(0x0000A4A600D86037 AS DateTime), 1, CAST(0x0000A4A600D86003 AS DateTime), 0)
INSERT [dbo].[GuideLineDetailMore] ([IID], [GuideLineDetailID], [Title], [ImageUrl], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsRemoved]) VALUES (12, 11, N'fdgfdg', N'~/All Photos/GuideLine/GuideLineDetailMore/20150528131044558566553325325.jpg', N'fdgdfgfd', 1, CAST(0x0000A4A600D86052 AS DateTime), 1, CAST(0x0000A4A600F1B02B AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[GuideLineDetailMore] OFF
ALTER TABLE [dbo].[CMSContent] ADD  CONSTRAINT [DF_CMSContent_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[CommunityNews] ADD  CONSTRAINT [DF_CommunityNews_IsOnlyVideo]  DEFAULT ((0)) FOR [IsOnlyVideo]
GO
ALTER TABLE [dbo].[LISchema] ADD  CONSTRAINT [DF_LISchema_NumberOfYear]  DEFAULT ((1)) FOR [NumberOfYear]
GO
ALTER TABLE [dbo].[LISchema] ADD  CONSTRAINT [DF_LISchema_MultiplyFactor]  DEFAULT ((0)) FOR [MultiplyFactor]
GO
ALTER TABLE [dbo].[MortgageInterestRate] ADD  CONSTRAINT [DF_MortgageInterestRate_UptoYear]  DEFAULT ((0)) FOR [UptoYear]
GO
ALTER TABLE [dbo].[NewsLetterSubscribe] ADD  CONSTRAINT [DF_NewsLetterSubscribe_IsSubscribe]  DEFAULT ((0)) FOR [IsSubscribe]
GO
ALTER TABLE [dbo].[OiiOMart] ADD  CONSTRAINT [DF_OiiOMart_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UrlWFList] ADD  CONSTRAINT [DF_UrlWFList_ModuleNote]  DEFAULT ((0)) FOR [ModuleNote]
GO
ALTER TABLE [dbo].[UrlWFList] ADD  CONSTRAINT [DF_UrlWFList_ModuleImage]  DEFAULT ((0)) FOR [ModuleImage]
GO
ALTER TABLE [dbo].[UserGroup] ADD  CONSTRAINT [DF_UserGroup_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsEmail]  DEFAULT ((0)) FOR [IsEmail]
GO
ALTER TABLE [dbo].[VisitorCounter] ADD  CONSTRAINT [DF_VisitorCounter_TotalVisitor]  DEFAULT ((0)) FOR [TotalVisitor]
GO
ALTER TABLE [dbo].[VisitorInfo] ADD  CONSTRAINT [DF_VisitorInfo_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[VisitorInfoDetails] ADD  CONSTRAINT [DF_VisitorInfoDetails_IsRemoved]  DEFAULT ((0)) FOR [IsRemoved]
GO
ALTER TABLE [dbo].[AllFeatureDetail]  WITH CHECK ADD  CONSTRAINT [FK_AllFeatureDetail_AllFeature] FOREIGN KEY([AllFeatureID])
REFERENCES [dbo].[AllFeature] ([IID])
GO
ALTER TABLE [dbo].[AllFeatureDetail] CHECK CONSTRAINT [FK_AllFeatureDetail_AllFeature]
GO
ALTER TABLE [dbo].[AllNewsDetail]  WITH CHECK ADD  CONSTRAINT [FK_AllNewsDetail_AllNews] FOREIGN KEY([AllNewsID])
REFERENCES [dbo].[AllNews] ([IID])
GO
ALTER TABLE [dbo].[AllNewsDetail] CHECK CONSTRAINT [FK_AllNewsDetail_AllNews]
GO
ALTER TABLE [dbo].[Applicant]  WITH CHECK ADD  CONSTRAINT [FK_Applicant_Profession] FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[Profession] ([IID])
GO
ALTER TABLE [dbo].[Applicant] CHECK CONSTRAINT [FK_Applicant_Profession]
GO
ALTER TABLE [dbo].[BDInternet]  WITH CHECK ADD  CONSTRAINT [FK_BDInternet_CompanyInfo] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[BDInternet] CHECK CONSTRAINT [FK_BDInternet_CompanyInfo]
GO
ALTER TABLE [dbo].[BDInternetAndChannelMapping]  WITH CHECK ADD  CONSTRAINT [FK_BDInternetAndChannelMapping_BDChannelInfo] FOREIGN KEY([BDChannelInfoID])
REFERENCES [dbo].[BDChannelInfo] ([IID])
GO
ALTER TABLE [dbo].[BDInternetAndChannelMapping] CHECK CONSTRAINT [FK_BDInternetAndChannelMapping_BDChannelInfo]
GO
ALTER TABLE [dbo].[BDInternetAndChannelMapping]  WITH CHECK ADD  CONSTRAINT [FK_BDInternetAndChannelMapping_BDInternet] FOREIGN KEY([BDInternetID])
REFERENCES [dbo].[BDInternet] ([IID])
GO
ALTER TABLE [dbo].[BDInternetAndChannelMapping] CHECK CONSTRAINT [FK_BDInternetAndChannelMapping_BDInternet]
GO
ALTER TABLE [dbo].[BICategoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_BICategoryDetail_BICategory] FOREIGN KEY([BICategoryID])
REFERENCES [dbo].[BICategory] ([IID])
GO
ALTER TABLE [dbo].[BICategoryDetail] CHECK CONSTRAINT [FK_BICategoryDetail_BICategory]
GO
ALTER TABLE [dbo].[BusinessInsuranceReceiverDetail]  WITH CHECK ADD  CONSTRAINT [FK_BusinessInsuranceReceiverDetail_BIAmountRange] FOREIGN KEY([BIAmountRangeID])
REFERENCES [dbo].[BIAmountRange] ([IID])
GO
ALTER TABLE [dbo].[BusinessInsuranceReceiverDetail] CHECK CONSTRAINT [FK_BusinessInsuranceReceiverDetail_BIAmountRange]
GO
ALTER TABLE [dbo].[BusinessInsuranceReceiverDetail]  WITH CHECK ADD  CONSTRAINT [FK_BusinessInsuranceReceiverDetail_BusinessInsuranceReceiver] FOREIGN KEY([BusinessInsuranceReceiverID])
REFERENCES [dbo].[BusinessInsuranceReceiver] ([IID])
GO
ALTER TABLE [dbo].[BusinessInsuranceReceiverDetail] CHECK CONSTRAINT [FK_BusinessInsuranceReceiverDetail_BusinessInsuranceReceiver]
GO
ALTER TABLE [dbo].[CardBalanceTransfer]  WITH CHECK ADD  CONSTRAINT [FK_CardBalanceTransfer_CardInfo] FOREIGN KEY([CardInfoID])
REFERENCES [dbo].[CardInfo] ([IID])
GO
ALTER TABLE [dbo].[CardBalanceTransfer] CHECK CONSTRAINT [FK_CardBalanceTransfer_CardInfo]
GO
ALTER TABLE [dbo].[CardFeature]  WITH CHECK ADD  CONSTRAINT [FK_CardFeature_CardInfo] FOREIGN KEY([CardInfoID])
REFERENCES [dbo].[CardInfo] ([IID])
GO
ALTER TABLE [dbo].[CardFeature] CHECK CONSTRAINT [FK_CardFeature_CardInfo]
GO
ALTER TABLE [dbo].[CardInfo]  WITH CHECK ADD  CONSTRAINT [FK_CardInfo_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[CardInfo] CHECK CONSTRAINT [FK_CardInfo_CompanyInfo]
GO
ALTER TABLE [dbo].[CardPostDisplayHistory]  WITH CHECK ADD  CONSTRAINT [FK_CardPostDisplayHistory_CardInfo] FOREIGN KEY([CardInfoID])
REFERENCES [dbo].[CardInfo] ([IID])
GO
ALTER TABLE [dbo].[CardPostDisplayHistory] CHECK CONSTRAINT [FK_CardPostDisplayHistory_CardInfo]
GO
ALTER TABLE [dbo].[CardPurchase]  WITH CHECK ADD  CONSTRAINT [FK_CardPurchase_CardInfo] FOREIGN KEY([CardInfoID])
REFERENCES [dbo].[CardInfo] ([IID])
GO
ALTER TABLE [dbo].[CardPurchase] CHECK CONSTRAINT [FK_CardPurchase_CardInfo]
GO
ALTER TABLE [dbo].[CardRegionWiseFee]  WITH CHECK ADD  CONSTRAINT [FK_CardRegionWiseFee_CardInfo] FOREIGN KEY([CardInfoID])
REFERENCES [dbo].[CardInfo] ([IID])
GO
ALTER TABLE [dbo].[CardRegionWiseFee] CHECK CONSTRAINT [FK_CardRegionWiseFee_CardInfo]
GO
ALTER TABLE [dbo].[CarDriving]  WITH CHECK ADD  CONSTRAINT [FK_CarDriving_Applicant] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[Applicant] ([IID])
GO
ALTER TABLE [dbo].[CarDriving] CHECK CONSTRAINT [FK_CarDriving_Applicant]
GO
ALTER TABLE [dbo].[CarInformation]  WITH CHECK ADD  CONSTRAINT [FK_CarInformation_Applicant] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[Applicant] ([IID])
GO
ALTER TABLE [dbo].[CarInformation] CHECK CONSTRAINT [FK_CarInformation_Applicant]
GO
ALTER TABLE [dbo].[CarInformation]  WITH CHECK ADD  CONSTRAINT [FK_CarInformation_CarBrand] FOREIGN KEY([CarBrandID])
REFERENCES [dbo].[CarBrand] ([IID])
GO
ALTER TABLE [dbo].[CarInformation] CHECK CONSTRAINT [FK_CarInformation_CarBrand]
GO
ALTER TABLE [dbo].[CarInsurance]  WITH CHECK ADD  CONSTRAINT [FK_CarInsurance_CarInsuranceParameter] FOREIGN KEY([CarInsuranceParameterID])
REFERENCES [dbo].[CarInsuranceParameter] ([IID])
GO
ALTER TABLE [dbo].[CarInsurance] CHECK CONSTRAINT [FK_CarInsurance_CarInsuranceParameter]
GO
ALTER TABLE [dbo].[CarInsurance]  WITH CHECK ADD  CONSTRAINT [FK_CarInsurance_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[CarInsurance] CHECK CONSTRAINT [FK_CarInsurance_CompanyInfo]
GO
ALTER TABLE [dbo].[CarInsuranceFeature]  WITH CHECK ADD  CONSTRAINT [FK_CarInsuranceFeature_CarInsurance] FOREIGN KEY([CarInsuranceID])
REFERENCES [dbo].[CarInsurance] ([IID])
GO
ALTER TABLE [dbo].[CarInsuranceFeature] CHECK CONSTRAINT [FK_CarInsuranceFeature_CarInsurance]
GO
ALTER TABLE [dbo].[CarModelInfo]  WITH CHECK ADD  CONSTRAINT [FK_CarModelInfo_CarBrand] FOREIGN KEY([CarBrandID])
REFERENCES [dbo].[CarBrand] ([IID])
GO
ALTER TABLE [dbo].[CarModelInfo] CHECK CONSTRAINT [FK_CarModelInfo_CarBrand]
GO
ALTER TABLE [dbo].[CompanyInfo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyInfo_Country] FOREIGN KEY([OriginCountryID])
REFERENCES [dbo].[Country] ([IID])
GO
ALTER TABLE [dbo].[CompanyInfo] CHECK CONSTRAINT [FK_CompanyInfo_Country]
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
ALTER TABLE [dbo].[GasAvailableArea]  WITH CHECK ADD  CONSTRAINT [FK_GasAvailableArea_GasCyliender] FOREIGN KEY([GasCylienderID])
REFERENCES [dbo].[GasCyliender] ([IID])
GO
ALTER TABLE [dbo].[GasAvailableArea] CHECK CONSTRAINT [FK_GasAvailableArea_GasCyliender]
GO
ALTER TABLE [dbo].[GasCyliender]  WITH CHECK ADD  CONSTRAINT [FK_GasCyliender_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[GasCyliender] CHECK CONSTRAINT [FK_GasCyliender_CompanyInfo]
GO
ALTER TABLE [dbo].[GasCylinderAndDealerInfoMapping]  WITH CHECK ADD  CONSTRAINT [FK_GasCylinderAndDealerInfoMapping_GasCyliender] FOREIGN KEY([GasCylinderID])
REFERENCES [dbo].[GasCyliender] ([IID])
GO
ALTER TABLE [dbo].[GasCylinderAndDealerInfoMapping] CHECK CONSTRAINT [FK_GasCylinderAndDealerInfoMapping_GasCyliender]
GO
ALTER TABLE [dbo].[GasCylinderAndDealerInfoMapping]  WITH CHECK ADD  CONSTRAINT [FK_GasCylinderAndDealerInfoMapping_GasDealerInfo] FOREIGN KEY([GasDealerInfoID])
REFERENCES [dbo].[GasDealerInfo] ([IID])
GO
ALTER TABLE [dbo].[GasCylinderAndDealerInfoMapping] CHECK CONSTRAINT [FK_GasCylinderAndDealerInfoMapping_GasDealerInfo]
GO
ALTER TABLE [dbo].[GuideLineDetail]  WITH CHECK ADD  CONSTRAINT [FK_GuideLineDetail_GuideLine] FOREIGN KEY([GuideLineID])
REFERENCES [dbo].[GuideLine] ([IID])
GO
ALTER TABLE [dbo].[GuideLineDetail] CHECK CONSTRAINT [FK_GuideLineDetail_GuideLine]
GO
ALTER TABLE [dbo].[GuideLineDetailMore]  WITH CHECK ADD  CONSTRAINT [FK_GuideLineDetailMore_GuideLineDetail] FOREIGN KEY([GuideLineDetailID])
REFERENCES [dbo].[GuideLineDetail] ([IID])
GO
ALTER TABLE [dbo].[GuideLineDetailMore] CHECK CONSTRAINT [FK_GuideLineDetailMore_GuideLineDetail]
GO
ALTER TABLE [dbo].[HomeInfo]  WITH CHECK ADD  CONSTRAINT [FK_HomeInfo_Applicant] FOREIGN KEY([ApplicantID])
REFERENCES [dbo].[Applicant] ([IID])
GO
ALTER TABLE [dbo].[HomeInfo] CHECK CONSTRAINT [FK_HomeInfo_Applicant]
GO
ALTER TABLE [dbo].[LIApplicableFeature]  WITH CHECK ADD  CONSTRAINT [FK_LIApplicableFeature_LISchema] FOREIGN KEY([LISchemaID])
REFERENCES [dbo].[LISchema] ([IID])
GO
ALTER TABLE [dbo].[LIApplicableFeature] CHECK CONSTRAINT [FK_LIApplicableFeature_LISchema]
GO
ALTER TABLE [dbo].[LifeInsurance]  WITH CHECK ADD  CONSTRAINT [FK_LifeInsurance_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[LifeInsurance] CHECK CONSTRAINT [FK_LifeInsurance_CompanyInfo]
GO
ALTER TABLE [dbo].[LifeInsurance]  WITH CHECK ADD  CONSTRAINT [FK_LifeInsurance_LISchema] FOREIGN KEY([LISchemaID])
REFERENCES [dbo].[LISchema] ([IID])
GO
ALTER TABLE [dbo].[LifeInsurance] CHECK CONSTRAINT [FK_LifeInsurance_LISchema]
GO
ALTER TABLE [dbo].[LoanAmtYearSchedule]  WITH CHECK ADD  CONSTRAINT [FK_LoanAmtYearSchedule_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[LoanAmtYearSchedule] CHECK CONSTRAINT [FK_LoanAmtYearSchedule_CompanyInfo]
GO
ALTER TABLE [dbo].[LoanFeature]  WITH CHECK ADD  CONSTRAINT [FK_LoanFeature_LoanInfo] FOREIGN KEY([LoanInfoID])
REFERENCES [dbo].[LoanInfo] ([IID])
GO
ALTER TABLE [dbo].[LoanFeature] CHECK CONSTRAINT [FK_LoanFeature_LoanInfo]
GO
ALTER TABLE [dbo].[LoanInfo]  WITH CHECK ADD  CONSTRAINT [FK_LoanInfo_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[LoanInfo] CHECK CONSTRAINT [FK_LoanInfo_CompanyInfo]
GO
ALTER TABLE [dbo].[LoanPostDisplayHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoanPostDisplayHistory_LoanInfo] FOREIGN KEY([LoanInfoID])
REFERENCES [dbo].[LoanInfo] ([IID])
GO
ALTER TABLE [dbo].[LoanPostDisplayHistory] CHECK CONSTRAINT [FK_LoanPostDisplayHistory_LoanInfo]
GO
ALTER TABLE [dbo].[MobilePhoneInfo]  WITH CHECK ADD  CONSTRAINT [FK_MobilePhoneInfo_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[MobilePhoneInfo] CHECK CONSTRAINT [FK_MobilePhoneInfo_CompanyInfo]
GO
ALTER TABLE [dbo].[Mortgage]  WITH CHECK ADD  CONSTRAINT [FK_Mortgage_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[Mortgage] CHECK CONSTRAINT [FK_Mortgage_CompanyInfo]
GO
ALTER TABLE [dbo].[Mortgage]  WITH CHECK ADD  CONSTRAINT [FK_Mortgage_MortgageTermYear] FOREIGN KEY([TermYearID])
REFERENCES [dbo].[MortgageTermYear] ([IID])
GO
ALTER TABLE [dbo].[Mortgage] CHECK CONSTRAINT [FK_Mortgage_MortgageTermYear]
GO
ALTER TABLE [dbo].[MortgageInterestRate]  WITH CHECK ADD  CONSTRAINT [FK_MortgageInterestRate_Mortgage] FOREIGN KEY([MortgageID])
REFERENCES [dbo].[Mortgage] ([IID])
GO
ALTER TABLE [dbo].[MortgageInterestRate] CHECK CONSTRAINT [FK_MortgageInterestRate_Mortgage]
GO
ALTER TABLE [dbo].[MPFeature]  WITH CHECK ADD  CONSTRAINT [FK_MPFeature_MobilePhoneInfo] FOREIGN KEY([MobilePhoneID])
REFERENCES [dbo].[MobilePhoneInfo] ([IID])
GO
ALTER TABLE [dbo].[MPFeature] CHECK CONSTRAINT [FK_MPFeature_MobilePhoneInfo]
GO
ALTER TABLE [dbo].[MPType]  WITH CHECK ADD  CONSTRAINT [FK_MPType_CompanyInfo] FOREIGN KEY([CompanyInfoID])
REFERENCES [dbo].[CompanyInfo] ([IID])
GO
ALTER TABLE [dbo].[MPType] CHECK CONSTRAINT [FK_MPType_CompanyInfo]
GO
ALTER TABLE [dbo].[PoliceStation]  WITH CHECK ADD  CONSTRAINT [FK_PoliceStation_District] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[District] ([IID])
GO
ALTER TABLE [dbo].[PoliceStation] CHECK CONSTRAINT [FK_PoliceStation_District]
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Main Page, Detail Page, More Detail Page...........' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdLogInfo', @level2type=N'COLUMN',@level2name=N'DisplayOnPageID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'public enum BussinessType
        {
            Energy =1,
            Banking =2,
            Travel =3,
            Insurance =4,
            Shopping =5,
            MobilePhone =6,
            NetworkServiceProvider =7,
            BroadBand=8,
            NewsAndCommunity=9,
            Construction =10,
            Medicine =11
        }' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AllFeature', @level2type=N'COLUMN',@level2name=N'BusinessTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'enum BussinessType-> Insurance,  public enum InsuranceType
        {
            BusinessInsurance=1,
            LifeInsurance=2, 
            CarInsurance=3,  
            HomeInsurance=4, 
            PersonalLoan=5, 
            HouseLoan=6
        }' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AllFeature', @level2type=N'COLUMN',@level2name=N'BusinessTypeBreakdownID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'public enum BussinessType
        {
            Energy =1,
            Banking =2,
            Travel =3,
            Insurance =4,
            Shopping =5,
            MobilePhone =6,
            NetworkServiceProvider =7,
            BroadBand=8,
            NewsAndCommunity=9,
            Construction =10,
            Medicine =11
        }' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AllNews', @level2type=N'COLUMN',@level2name=N'BusinessTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'enum BussinessType-> Insurance,  public enum InsuranceType
        {
            BusinessInsurance=1,
            LifeInsurance=2, 
            CarInsurance=3,  
            HomeInsurance=4, 
            PersonalLoan=5, 
            HouseLoan=6
        }' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AllNews', @level2type=N'COLUMN',@level2name=N'BusinessTypeBreakdownID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Male, Femal, Other' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'GenderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Never,Leave Six Month Ago, Leave One Year Ago, Leave Five Year Ago,............' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'SmokingHistoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Business Insurance, Car Insurance,  Home Insurance, Personal Loan, House Loan....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'ApplicationFor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'None, By All Media,  By Email, By Phone  Call, By Phone Text Message...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'WantMoreInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'yes = true, no = false' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applicant', @level2type=N'COLUMN',@level2name=N'HaveAdditionalJob'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CompanyInfoID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'ProviderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Broadband(Wire connection), Mobile Broadband(Wireless connection), Broadband and TV.....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KB, MB, GB...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'NetSpeedUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Using same enum NetSpeedUnitID''s unit-->KB, MB, GB...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'DownloadSpeedUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  public enum ConnectionType
         {
             TwoG = 1,
             ThreeG = 2,
             ThreePointFiveG = 3,
             FourG = 4,
             FourPointFiveG = 5, 
             FiveG = 6
         }' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'NetGenerationID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monthly, Quatarly,  HalfYearly, Yearly.....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BDInternet', @level2type=N'COLUMN',@level2name=N'ChargeTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indemnity Amount, Public Liability, EmployerLiability, Office Equipment, Portable Equipment,.......' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIAmountRange', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For Zero amount detail will be Not Applicable, Start Amount 1000 and End Amount 20000(Amount range) amount detail will be 1000- 20000 Taka..... ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIAmountRange', @level2type=N'COLUMN',@level2name=N'AmountDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'company age , such as 0 to 1 year......' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIBusinessAge', @level2type=N'COLUMN',@level2name=N'AgeInterval'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For Zero amount detail will be Not Applicable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIEmployeeLiability', @level2type=N'COLUMN',@level2name=N'AmountDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For Zero amount detail will be Not Applicable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIOfficeEquipment', @level2type=N'COLUMN',@level2name=N'AmountDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For Zero amount detail will be Not Applicable' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BIPublicLiability', @level2type=N'COLUMN',@level2name=N'AmountDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'this table data is display for all business insurance page. table not completed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BusinessInsurance'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BusinessInsuranceReceiverDetail', @level2type=N'COLUMN',@level2name=N'BIAmountRangeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'After how many month balance can be transfer to other account.  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardBalanceTransfer', @level2type=N'COLUMN',@level2name=N'MonthNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Full Name of card, Prime Bank Master Card' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Visa, Master, American Express.....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'CardTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DebitBalance, CreadBalance ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'BalanceTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Annual Percentage Rate. APR allows lender to evaluate the cost of the loan in terms of a percentage.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'APR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fee percent for -  world wide  transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'WholeWorldUsageFeePer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardInfo', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardPostDisplayHistory', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asia, Africa, European...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CardRegionWiseFee', @level2type=N'COLUMN',@level2name=N'RegionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Light Car, Bus, Truck...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarDriving', @level2type=N'COLUMN',@level2name=N'LicenceTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Licence hold year' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarDriving', @level2type=N'COLUMN',@level2name=N'LicenceYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monthly, Quaterly, HalfYearly. Yearly...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarDriving', @level2type=N'COLUMN',@level2name=N'PremiumPayTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Family purpose, Business purpose, Official purpose...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInformation', @level2type=N'COLUMN',@level2name=N'UsingCarFor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Home Garage, At Office, Rent Garage...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInformation', @level2type=N'COLUMN',@level2name=N'ParkingPlaceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How many car you have.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInformation', @level2type=N'COLUMN',@level2name=N'NumberOfCar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FixedTotalAmount + FixedVoluntaryAmount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsurance', @level2type=N'COLUMN',@level2name=N'FixedCompulsoryAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'(CarValueAmount*(PremiumTotalPercent of CarInsuranceParameter/100))/Duration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsurance', @level2type=N'COLUMN',@level2name=N'AnnuallyGrossAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pay within 10 , 13, 15 .... month' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsurance', @level2type=N'COLUMN',@level2name=N'TotalMonth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Premium amount = AnnuallyGrossAmount / TotalMonth' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsurance', @level2type=N'COLUMN',@level2name=N'InstallmentAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bus, Track, Private Car, Motor cycle,....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'CarTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'New, Recondition, Old...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'CarConditionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How many kilometer run' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'MinRun'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How many kilometer run' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'MaxRun'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Respect MinCarValueAmount and MaxCarValueAmount defined by insurance company. If Car value is X taka, than total premium amount is (X*(PremiumTotalAmount/100))' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'PremiumTotalPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Insurance duration year' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarInsuranceParameter', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Diesel, Petrol, Octan, CNG...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarModelInfo', @level2type=N'COLUMN',@level2name=N'FuelTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Manual, Auto...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarModelInfo', @level2type=N'COLUMN',@level2name=N'TransmissionModeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Meter, Inch,  feet....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CarModelInfo', @level2type=N'COLUMN',@level2name=N'WheelSizeUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'About OiiO Mart, Work with us, Our Partners, Privacy & Policy, Terms of use, Contact with us' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CMSContent', @level2type=N'COLUMN',@level2name=N'CMSTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NetworkServiceProvider, Construction, Medicine...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CompanyInfo', @level2type=N'COLUMN',@level2name=N'BussinessTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'All Division, All District, All Thana..... ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GasAvailableArea', @level2type=N'COLUMN',@level2name=N'AreaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Only Gas, Gas plus Cylinder...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GasCyliender', @level2type=N'COLUMN',@level2name=N'PriceNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jamuna LP Gas, Bashundhra LP Gas......... ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GasDealerInfo', @level2type=N'COLUMN',@level2name=N'CompanyInfoID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Square feet, Square Meter...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'FloorSizeUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Square feet, Square Meter...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'ParkingSpaceSizeUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FloorSize * FloorNumberOfBuilding' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'TotalFloorSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Electricity, Solar, Generator, Electricity And Solar, Electricity And Generator..' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'PowerSupplyTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'None, City Corporation, Self Deep Pump...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'WaterSupplyTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'National Gride, Cylinder.....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'GasSupplyTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Construction date means construction finishing year.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HomeInfo', @level2type=N'COLUMN',@level2name=N'ConstructionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Duration of insurance' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LISchema', @level2type=N'COLUMN',@level2name=N'NumberOfYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Customer minimum age limit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LISchema', @level2type=N'COLUMN',@level2name=N'AgeMin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Customer maximum age limit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LISchema', @level2type=N'COLUMN',@level2name=N'AgeMax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minimum insurance amount. Total insurance amount  is multiply of 1 to 100 to 1000.........' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LISchema', @level2type=N'COLUMN',@level2name=N'UnitAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monthly,Quarterly,HalfYearly,Yearly...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LISchema', @level2type=N'COLUMN',@level2name=N'PremiumPolicyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Year duration - 1 , 2 3, 4.....year' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanAmtYearSchedule', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'APR- Annual Percentage Rate. APR allows lender to evaluate the cost of the loan in terms of a percentage. Value is 3, 3.5, ....100, 100.3..... Example: 0-1 year 3%, 1-3 year 3.5 % ....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanAmtYearSchedule', @level2type=N'COLUMN',@level2name=N'APR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Loan amount and number of year wise APR schedule' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanAmtYearSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Personal, Car, Marriage, Home, SME....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanInfo', @level2type=N'COLUMN',@level2name=N'LoanTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanInfo', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoanPostDisplayHistory', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Network service provider company (CompanyID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'NetworkProviderID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'None,OnlySIM, PhoneWithOneSIM, PhoneWithTwoSIM, PhoneWithThreeSIM...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'SIMAvailableID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minute, Hour, Day...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'TalkTimeUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MB, GB...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'UsableDataUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'2G, 3G, 3.5G, 4G, 4.5G, 5G' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'ConnectionTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'how many month take time for pay total amount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'ContractDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MobilePhoneInfo', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'OperationTypeID - MortgageOperationType enum value, New Client, Remortgage...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'OperationTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MortgageType enum-->Conventional, Government, Rural Home Financing Program, Home Opportunities Program, Noneprime or Subprime......' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Annual Percentage Rate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'APR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MortgageTermYear->IID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'TermYearID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Regular principal and interest payment, Interest-only payment, Balloon payment, Prepayment with no penalty or fee, Prepayment with a penalty or fee....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'PaymentTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LTV - Loan-to-Value, ratio assets respect loan amount, assest''s - 70%, 75%, 80%....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'LTV'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Payment for ad post' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Mortgage', @level2type=N'COLUMN',@level2name=N'PaymentAmt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fixed-Rate Mortgage(FRM), Adjustable-Rate Mortgage(ARM), Initial monthly payment....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MortgageInterestRate', @level2type=N'COLUMN',@level2name=N'InterestRateTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mortgage time duration slot, 10 15, 20, 25 ....years' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MortgageTermYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'iPad, iPhone, NotePad, Start Pro, Black Berry....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MPType', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MP->Mobile Phone' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MPType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Self-Employeed, Employee, Businessman....' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profession', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Self-Employeed->Doctor, Engineer............, ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Profession', @level2type=N'COLUMN',@level2name=N'Name'
GO
USE [master]
GO
ALTER DATABASE [OiiOMart_Live] SET  READ_WRITE 
GO
