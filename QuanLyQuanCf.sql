CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo


CREATE TABLE TableFood
(
	id INT NOT NULL PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL,
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO


CREATE TABLE NhanVien
(
	id INT IDENTITY PRIMARY KEY,
	Ten NVARCHAR(50),
	NgaySinh DATETIME,
	GioiTinh NVARCHAR(5) CHECK(GioiTinh IN (N'Nam', N'Nữ')),
	DiaChi NVARCHAR(100),
	Sdt NVARCHAR(11),
	TienLuong FLOAT
)



GO
INSERT INTO NhanVien
VALUES ( N'Nguyễn Văn Long', '1/12/1997', 'Nam', N'Quận Tân Phú','0987654321', 1000000)
INSERT INTO NhanVien
VALUES ( N'Nguyễn Văn Hưng', '5/18/1997','Nam', N'Quận Tân Phú', '0987456321', 1000000)
INSERT INTO NhanVien
VALUES ( N'Nguyễn Thị Hồng', '1/2/1997',N'Nữ', N'Quận Bình Thạnh', '0900054321', 800000)
INSERT INTO NhanVien
VALUES ( N'Trần Văn Phi', '11/28/1997','Nam', N'Quận 2', '0987654321', 1000000)
INSERT INTO NhanVien
VALUES ( N'Nguyễn Thị Mai', '10/7/1997',N'Nữ', N'Quận Bình Thạnh', '0987654321', 800000)
GO

CREATE TABLE TypeAccount
(
type INT NOT NULL DEFAULT 0 PRIMARY KEY,
name NVARCHAR(100)
)


INSERT dbo.TypeAccount
        ( type, name )
VALUES  ( 1, -- type - int
          N'Quản lý'  -- name - varchar(10)
          )

INSERT dbo.TypeAccount VALUES  ( 0, -- type - int
						   N'Nhân viên'  -- name - varchar(10)
							  )

CREATE TABLE FoodCategory
(
	id INT IDENTITY NOT NULL PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE TableStatus 
(
name NVARCHAR(20) NOT NULL PRIMARY KEY
)
GO

INSERT dbo.TableStatus
        ( name )
VALUES  ( N'Có người'  -- name - nvarchar(20)
          )


INSERT dbo.TableStatus
        ( name )
VALUES  ( N'Trống'  -- name - nvarchar(20)
          )

GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- 1: đã thanh toán && 0: chưa thanh toán
	disCount INT ,
	totalPrice FLOAT,
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	countFood INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO
CREATE TABLE GioiTinh
(
gioitinh NVARCHAR(5) NOT NULL PRIMARY KEY
)
GO

INSERT dbo.GioiTinh
        ( gioitinh )
VALUES  ( N'Nam'  -- gioitinh - nvarchar(5)
          )


INSERT dbo.GioiTinh
        ( gioitinh )
VALUES  ( N'Nữ'  -- gioitinh - nvarchar(5)
          )


GO

CREATE PROC USP_InsertNhanVien
@Ten NVARCHAR(100),
@NgaySinh DATETIME,
@GioiTinh NVARCHAR(5),
@DiaChi NVARCHAR(100),
@Sdt VARCHAR(11),
@TienLuong FLOAT
AS
BEGIN 
INSERT dbo.NhanVien
        ( Ten ,
          NgaySinh ,
          GioiTinh ,
          DiaChi ,
          Sdt ,
          TienLuong
        )
VALUES  ( @Ten , -- Ten - nvarchar(50)
          @NgaySinh, -- NgaySinh - datetime
          @GioiTinh , -- GioiTinh - nvarchar(5)
          @DiaChi, -- DiaChi - nvarchar(100)
          @Sdt, -- Sdt - nvarchar(11)
          @TienLuong -- TienLuong - float
        )
END
GO

CREATE PROC USP_UpdateNhanVien
@id INT,
@Ten NVARCHAR(100),
@NgaySinh DATETIME,
@GioiTinh NVARCHAR(5),
@DiaChi NVARCHAR(100),
@Sdt VARCHAR(11),
@TienLuong FLOAT
AS
BEGIN 
UPDATE dbo.NhanVien SET Ten = @Ten,NgaySinh = @NgaySinh, GioiTinh = @GioiTinh,DiaChi= @DiaChi,Sdt = @Sdt, TienLuong = @TienLuong WHERE id = @id
END
GO



INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'Boss' , -- UserName - nvarchar(100)
          N'Boss' , -- DisplayName - nvarchar(100)
          N'246253255228140144141235157659211108346114', -- PassWord - nvarchar(1000)
          1  -- Type - int
        )

GO

--HÀM LOGIN
create proc USP_Login
@userName nvarchar(100), @passWord nvarchar(1000)
As
Begin
	select * from dbo.Account where dbo.Account.Username = @userName and dbo.Account.PassWord = @passWord
End

go

-- TẠO DANH SÁCH BÀN --co chinh sua identity ban vs category
DECLARE @i int = 0 
while @i < 16
BEGIN
	Insert dbo.TableFood (id,name) values (@i+1,N'Bàn ' + CAST((@i+1) as nvarchar(100)))
	SET @i = @i + 1
END


go

create Proc USP_getTableList
AS
	SELECT * from dbo.TableFood

exec dbo.USP_getTableList 
go


-- INSERT FOOD CATEGORY
INSERT dbo.FoodCategory VALUES  ( N'Cafe truyền thống' )
INSERT dbo.FoodCategory VALUES  (N'Cafe Espresso' )
INSERT dbo.FoodCategory VALUES  ( N'Cafe FREEZE' )
INSERT dbo.FoodCategory VALUES  ( N'Thức uống khác'  )
INSERT dbo.FoodCategory VALUES  ( N'Bò Nướng')
INSERT dbo.FoodCategory VALUES  ( N'Heo Nướng' )
INSERT dbo.FoodCategory VALUES  ( N'Xiên Nướng')
INSERT dbo.FoodCategory VALUES  ( N'Các Món Nướng Khác')

-- INSERT FOOD
INSERT dbo.Food
VALUES  (  N'Cafe Sữa Đá',
          1, -- idCategory - int
          29000.0  -- price - float
          )

INSERT dbo.Food
VALUES  ( N'Cafe Đen Đá',
          1, -- idCategory - int
          29000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Cafe Sữa Nóng',
          1, -- idCategory - int
          29000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  ( N'Cafe Đen Nóng',
          1, -- idCategory - int
          29000.0  -- price - float
          )

		  
INSERT dbo.Food
VALUES  (  N'Epresso normal',
          2, -- idCategory - int
          44000.0  -- price - float
          )
	  
INSERT dbo.Food
VALUES  (  N'Epresso big',
          2, -- idCategory - int
          54000.0  -- price - float
          )
	  
INSERT dbo.Food
VALUES  (  N'Americano normal',
          2, -- idCategory - int
          44000.0  -- price - float
          )
		  	  
INSERT dbo.Food
VALUES  (  N'Americano big',
          2, -- idCategory - int
          54000.0  -- price - float
          )
		  	  
INSERT dbo.Food
VALUES  ( N'Cappuccino normal',
          2, -- idCategory - int
          54000.0  -- price - float
          )
		  	  	  
INSERT dbo.Food
VALUES  (  N'Cappuccino big',
          2, -- idCategory - int
          64000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Latte normal',
          2, -- idCategory - int
          54000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Latte big',
          2, -- idCategory - int
          64000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Mocha normal',
          2, -- idCategory - int
          59000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Mocha big',
          2, -- idCategory - int
          69000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Caramel Macchiato normal',
          2, -- idCategory - int
          59000.0  -- price - float
          )

		  
INSERT dbo.Food
VALUES  (  N'Caramel Macchiato big',
          2, -- idCategory - int
          69000.0  -- price - float
          )

		  
INSERT dbo.Food
VALUES  ( N'Caramel Jelly Freeze',
          3, -- idCategory - int
          55000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Hazelnut Jelly Freeze',
          3, -- idCategory - int
          55000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Classic Jelly Freeze',
          3, -- idCategory - int
          55000.0  -- price - float
          )



INSERT dbo.Food
VALUES  ( N'Chanh Đá Xay',
          4, -- idCategory - int
          39000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Bưởi Đá Xay',
          4, -- idCategory - int
          54000.0  -- price - float
          )

INSERT dbo.Food
VALUES  ( N'Socola Nóng/Đá',
          4, -- idCategory - int
          54000.0  -- price - float
          )
	  
INSERT dbo.Food
VALUES  (  N'Trà Xoài',
          4, -- idCategory - int
          59000.0  -- price - float
          )
	  
INSERT dbo.Food
VALUES  ( N'Mojito Chanh',
          4, -- idCategory - int
          59000.0  -- price - float
          )

INSERT dbo.Food
VALUES  (  N'Ba Chỉ Bò Mỹ sốt thịt tươi',
          5, -- idCategory - int
          150000.0  -- price - float
          )

		  
INSERT dbo.Food
VALUES  (  N'Thăn Vai Bò sốt momi',
          5, -- idCategory - int
          230000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  ( N'Bắp Bò Úc sốt Momi',
          5, -- idCategory - int
          170000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Ba Chỉ Bò Mỹ sốt Yaki',
          5, -- idCategory - int
          170000.0  -- price - float
          )


INSERT dbo.Food
VALUES  (  N'Cổ Heo Sốt Mắm Nhật',
          6, -- idCategory - int
          130000.0  -- price - float
          )

		  

INSERT dbo.Food
VALUES  ( N'Ba Chỉ Heo sốt Miso',
          6, -- idCategory - int
          130000.0  -- price - float
          )
		  

INSERT dbo.Food
VALUES  ( N'Sườn Heo Sốt Mắm Nhật',
          6, -- idCategory - int
          130000.0  -- price - float
          )

		  

INSERT dbo.Food
VALUES  (  N'Ba Chỉ cuộn nắm',
          7, -- idCategory - int
          90000.0  -- price - float
          )
		  
		  
INSERT dbo.Food
VALUES  ( N'Bò Cuộn Cá Hồi',
          7, -- idCategory - int
          90000.0  -- price - float
          )
		  
INSERT dbo.Food
VALUES  (  N'Ba Chỉ cuộn Đậu Bắp',
          7, -- idCategory - int
          90000.0  -- price - float
          )
		  
		  
INSERT dbo.Food
VALUES  (  N'Đùi Gà sốt Miso',
          8, -- idCategory - int
          150000.0  -- price - float
)
		  
	  
INSERT dbo.Food
VALUES  (  N'Xúc Xích',
          8, -- idCategory - int
          60000.0  -- price - float
          )	 
		  
GO

CREATE PROC USP_insertBill
@idTable int
AS
BEGIN
INSERT dbo.Bill 
VALUES  ( 
	GETDATE() , -- DateCheckIn - date
	NULL , -- DateCheckOut - date
	@idTable , -- idTable - int
	0,  -- status - int
	0,  -- disCount
	0	           )
END
GO
-- HÀM CHÈN MỚI/BỔ SUNG MỘT BILL INFO 
CREATE PROC USP_insertBillInfo 
@idBill INT,
 @idFood INT, 
 @countFood INT
AS
BEGIN
	DECLARE @isExitBillInfo INT
	DECLARE @_countFood INT = 1

	SELECT @isExitBillInfo = Bi.id, @_countFood = Bi.countFood FROM dbo.BillInfo AS Bi 
	WHERE Bi.idBill = @idBill AND Bi.idFood = @idFood 

	IF(@isExitBillInfo > 0)
	BEGIN
		DECLARE @newCount  INT = @_countFood + @countFood
		IF(@newCount > 0)
			UPDATE dbo.BillInfo SET countFood  = @_countFood + @countFood WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo  WHERE idBill = @idBill AND idFood = @idFood
	END
	---
    ELSE
    BEGIN 
	INSERT dbo.BillInfo
	        ( idBill, idFood, countFood )
	VALUES  ( @idBill, -- idBill - int
	          @idFood, -- idFood - int
	          @countFood  -- countFood - int
	          )
	END
END
    

GO

CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT,UPDATE
AS
BEGIN 
DECLARE @idBill INT
DECLARE @idTable INT

SELECT @idBill = idBill FROM Inserted
SELECT @idTable = idTable FROM dbo.Bill WHERE id= @idBill AND status = 0

IF(@idTable IS NOT NULL)
	UPDATE dbo.TableFood SET status = N'Có người' WHERE @idTable = id
ELSE
    UPDATE dbo.TableFood SET status = N'Trống' WHERE @idTable = id
END
GO

CREATE TRIGGER UTG_UpdateBill 
ON dbo.Bill 
FOR UPDATE
AS
BEGIN 

DECLARE @idBill INT
SELECT @idBill = id FROM Inserted

DECLARE @idTable INT
SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill 

DECLARE @count INT = 0
SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status =0
IF(@count = 0)
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable

END
GO

CREATE PROC USP_SwitchTable 
@idTable1 INT, -- id bàn trên bill ( đang có người cần chuyển) 
@idTable2 INT  -- id bàn trên combobox ( vị trí chuyển đến)
AS
BEGIN
	DECLARE @idFisrtBill INT 
	DECLARE @idSecondBill INT 

	DECLARE @isEmptyTable1 INT = 0 -- không người
	DECLARE @isEmptyTable2 INT = 0 -- không người 

	SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFisrtBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	IF(@idFisrtBill IS NULL)
	BEGIN
		INSERT dbo.Bill
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0 , -- status - int
		          0,   -- disCount - int
				  0
		        )
		SELECT @idFisrtBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0 -- set id bằng id mới tạo được
		--UPDATE dbo.TableFood SET status = N'Trống' WHERE id= @idTable2
		
	END
	
	IF(@idSecondBill IS NULL)
	BEGIN
		INSERT dbo.Bill
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0 , -- status - int
		          0 , -- disCount - int
		          0
				)
		SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		--UPDATE dbo.TableFood SET status = N'Trống' WHERE id= @idTable1
	END

	-- chọn các billinfo từ table2 vào IDBillInfoTable
    SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
	-- set bàn 1 bằng bàn 2
	UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFisrtBill
	-- set bàn 1 bằng biến tạm đã lưu bàn 2
	UPDATE dbo.BillInfo SET idBill = @idFisrtBill WHERE id IN (SELECT * FROM IDBillInfoTable)

	-- kiểm tra sau khi chuyển để set static cho các bàn
	SELECT @isEmptyTable1 = COUNT(id) FROM dbo.BillInfo WHERE idBill = @idFisrtBill
	IF(@isEmptyTable1 = 0) -- nếu bàn 1 trống
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1 --set static về 'Trống''
	SELECT @isEmptyTable2 = COUNT(id) FROM dbo.BillInfo WHERE idBill = @idSecondBill
	IF(@isEmptyTable2 = 0) -- tương tự như trường hợp trên
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
	
	DROP TABLE IDBillInfoTable

END
GO

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END


GO

SELECT * FROM dbo.Account 
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory
SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo 
SELECT * FROM dbo.TableFood

--lay ra hóa đơn trong 1 khoảng nào đó
--SELECT * FROM dbo.Bill WHERE DateCheckIn >= '20171101' AND DateCheckOut <= '20171101'AND status = 1

--lấy những thông tin cần thiết cho người dùng
--SELECT *--t.name, b.DateCheckIn, b.DateCheckOut, b.disCount
--FROM Bill as b Join TableFood as t on b.id = t.id--, BillInfo as bi, Food as f
--WHERE DateCheckIn >= '20171101' AND DateCheckOut <= '20171101'AND b.status = 1 --and b.id = bi.idBill and f.id = bi.idFood


--lấy những thông tin cần thiết cho người dùng
--SELECT t.name, b.DateCheckIn, b.DateCheckOut, b.disCount, b.totalPrice
--FROM Bill as b Join TableFood as t on b.id = t.id
--WHERE DateCheckIn >= '20171101' AND DateCheckOut <= '20171101'AND b.status = 1



CREATE PROC USP_ExistAcc
@username nvarchar(100)
AS
BEGIN 
SELECT * FROM dbo.Account WHERE UserName = @username
END

SELECT * FROM dbo.Account WHERE UserName = N'boss'

go
CREATE proc USP_GetListBillByDate 
@checkIn date, @checkOut date
as
begin
	SELECT b.id, t.name as [Tên Bàn], b.DateCheckIn as [Ngày vào], b.DateCheckOut as [Ngày ra], b.disCount as [Giảm giá], b.totalPrice as [Tổng tiền]
	FROM Bill b Join TableFood t on b.idTable = t.id
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1

end
GO


CREATE PROC USP_InsertTable
AS
BEGIN 
DECLARE @m_id INT = (SELECT MAX(id)FROM dbo.TableFood ) + 1
INSERT dbo.TableFood
        ( id, name, status )
VALUES  ( @m_id, -- id - int
          N'Bàn ' + CAST((@m_id) as nvarchar(100)), -- name - nvarchar(100)
          N'Trống'  -- status - nvarchar(100)
          )
END
GO

CREATE PROC USP_DeleteFoodCategory
@idCate INT
AS
BEGIN

DELETE dbo.BillInfo WHERE idFood IN (SELECT id FROM dbo.Food WHERE id = @idCate)
DELETE dbo.Food WHERE idCategory = @idCate
DELETE dbo.FoodCategory WHERE id  = @idCate
END
GO

CREATE PROC USP_DeleteTable 
@idTable INT
AS
BEGIN
DELETE dbo.BillInfo WHERE idBill IN (SELECT id FROM dbo.Bill WHERE idTable = @idTable)
DELETE dbo.Bill WHERE idTable = @idTable
DELETE dbo.TableFood WHERE id = @idTable
 
END
GO

---select * from Account

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

CREATE PROC USP_CreateNewAccount
@username NVARCHAR(100),@displayname NVARCHAR(100),@pass NVARCHAR(1000),@type INT 
AS
BEGIN
INSERT dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( @username , -- UserName - nvarchar(100)
          @displayname, -- DisplayName - nvarchar(100)
          @pass , -- PassWord - nvarchar(1000)
          @type-- Type - int
        )
END
GO

--select * from NhanVien
--khi xoa no tu dong vao ds ban hien thi



CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_UpdateAccount2
@username NVARCHAR(100),@displayname NVARCHAR(100),@type INT 
AS
BEGIN
UPDATE dbo.Account SET DisplayName = @displayname,Type = @type WHERE UserName = @username
END
GO


CREATE proc USP_GetListBillByDateAndPage
@checkIn date, @checkOut date,@page int 
as
begin
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page -1) * @pageRows

	;WITH BillShow AS  (SELECT b.id, t.name as [Tên Bàn], b.DateCheckIn as [Ngày vào], b.DateCheckOut as [Ngày ra], b.disCount as [Giảm giá], b.totalPrice as [Tổng tiền]
	FROM Bill b Join TableFood t on b.idTable = t.id
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1)

	SELECT TOP (@selectRows)* FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)

end
go

CREATE proc USP_GetNumBillByDate
@checkIn date, @checkOut date
as
begin
	SELECT COUNT(*)
	FROM Bill 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND status = 1

end
go

CREATE PROC USP_GetListBillByDateForReport
@checkIn DATETIME, @checkOut DATETIME
AS 
BEGIN
	
	SELECT t.name, b.totalPrice, DateCheckIn, DateCheckOut, discount
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut  <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

EXEC dbo.USP_GetListBillByDateForReport @checkIn = '2017-12-01 10:26:17', -- datetime
    @checkOut = '2017-12-31 10:26:17' -- datetime

