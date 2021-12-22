-- =============================================
-- Create database template
-- =============================================
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'WineStoreDb'
)
DROP DATABASE WineStoreDb
GO

CREATE DATABASE WineStoreDb
GO

USE WineStoreDb
GO
Create table [User]
(
	[UserId] Integer Identity NOT NULL,
	[UserName] Nvarchar(50) NOT NULL,
	[Email] Nvarchar(255) NULL,
	[Phone] Char(15) NULL,
	[Password] Char(50) NOT NULL,
	[Address] Nvarchar(255) NULL,
	[Status] Bit NULL,
	[CreateDate] Datetime Default GetDate() NULL,
	[ModifiedDate] Datetime Default GetDate() NULL,
	[GroupId] Integer NOT NULL,
Primary Key ([UserId])
) 
go

Create table [GroupUsers]
(
	[GroupId] Integer Identity NOT NULL,
	[GroupName] Nvarchar(50) NOT NULL,
Primary Key ([GroupId])
) 
go

Create table [Order]
(
	[OrderId] Integer Identity NOT NULL,
	[Status] Bit NULL,
	[CreateDate] Datetime Default GetDate() NULL,
	[ModifiedDate] Datetime Default GetDate() NULL,
	[UserId] Integer NOT NULL,
Primary Key ([OrderId])
) 
go

Create table [Catalogy]
(
	[CatalogyId] Integer Identity NOT NULL,
	[CatalogyName] Nvarchar(50) NULL,
	[Description] Nvarchar(255) NULL,
	[CreateDate] Datetime Default GetDate() NULL,
	[ModifiedDate] Datetime Default GetDate() NULL,
	[ParentId] Bit NULL,
Primary Key ([CatalogyId])
) 
go

Create table [Product]
(
	[ProductId] Integer Identity NOT NULL,
	[ProductName] Nvarchar(50) NULL,
	[Description] NTEXT NULL,
	[PurchasePrice] Money NULL,
	[Price] Money NULL,
	[Quantity] Integer NULL,
	[Vintage] Nvarchar(50) NULL,
	[Image] Nchar(50) NULL,
	[Region] Nvarchar(50) NULL,
	[Capacity] Integer NULL,
	[CreateDate] Datetime Default GetDate() NULL,
	[ModifiedDate] Datetime Default GetDate() NULL,
	[CatalogyId] Integer NOT NULL,
Primary Key ([ProductId])
) 
go

Create table [OrderDetails]
(
	[OrderId] Integer NOT NULL,
	[ProductId] Integer NOT NULL,
	[Quantity] Integer NULL,
	[Discount] Integer NULL,
Primary Key ([OrderId],[ProductId])
) 
go

Create table [Blog]
(
	[BlogId] Integer Identity NOT NULL,
	[Title] Nvarchar(50) NULL,
	[Content] NTEXT NULL,
	[Image] Nchar(50) NULL,
	[CreateDate] Datetime Default GetDate() NULL,
	[ModifiedDate] Datetime Default GetDate() NULL,
Primary Key ([BlogId])
) 
go


Alter table [Order] add  foreign key([UserId]) references [User] ([UserId])  on update no action on delete no action 
go
Alter table [User] add  foreign key([GroupId]) references [GroupUsers] ([GroupId])  on update no action on delete no action 
go
Alter table [OrderDetails] add  foreign key([OrderId]) references [Order] ([OrderId])  on update no action on delete no action 
go
Alter table [Product] add  foreign key([CatalogyId]) references [Catalogy] ([CatalogyId])  on update no action on delete no action 
go
Alter table [OrderDetails] add  foreign key([ProductId]) references [Product] ([ProductId])  on update no action on delete no action 
go
insert into GroupUsers values
('admin'),
('custom')

select * from GroupUsers

INSERT INTO dbo.[User]
(
    UserName,
    Email,
    Phone,
    Password,
    Address,
    Status,
    CreateDate,
    ModifiedDate,
    GroupId
)
VALUES
(N'hoang',N'hoan@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 1 ),
(N'Hoàng',N'hoang@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 1 ),
(N'Khải',N'khai@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 1 ),
(N'Phương',N'phuong@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 1 ),
(N'Việt',N'viet@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 2 ),
(N'Huy',N'huy@gmail.com','0333 444 555','admin123',N'Nam Định', 1,GETDATE(), GETDATE(), 2 )
SELECT * FROM dbo.[User]
INSERT INTO dbo.[Order]
(
    Status,
    CreateDate,
    ModifiedDate,
    UserId
)
VALUES
(1,GETDATE(),GETDATE(),4),
(1,GETDATE(),GETDATE(),4),
(1,GETDATE(),GETDATE(),5),
(1,GETDATE(),GETDATE(),5),
(0,GETDATE(),GETDATE(),5)
SELECT *FROM dbo.[Order]
INSERT INTO dbo.Catalogy
(
    CatalogyName,
    Description,
    CreateDate,
    ModifiedDate,
    ParentId
)
VALUES
(N' RƯỢU COGNAC',N'Rượu brandy được sản xuất trong khu vực Cognac, Pháp và phải tuân thủ luật làm rượu của vùng Cognac thì rượu mới có tên là Cognac. Đó là lý do tại sao Cognac còn có thể gọi là Brandy ',GETDATE(), GETDATE(),NULL),
(N'BLENDED SCOTCH WHISKY',N'Whisky như là một hình thức đặc biệt của rượu mạnh thông thường được uống để thưởng thức. Đóng góp vào đó trước tiên là những chất mang lại vị và hương thơm ',GETDATE(), GETDATE(),NULL),
(N'Rượu Single Malt',N'Rượu Single Malt Scotch Whisky hay còn gọi là rượu Whisky mạch nha đơn cất, để chỉ những chai rượu được làm từ 1 nhà chưng cất duy nhất từ lúa mạch nảy mầm',GETDATE(), GETDATE(),NULL),
(N'RƯỢU PHONG THUỶ - LINH VẬT',N'Rượu Phong Thủy Con Bò Tót · Rượu Phong Thủy Con Heo Rừng · Rượu Phong Thủy Bình Rồng Nhật · Rượu Phong Thủy Vương Tài Kim Ngưu 2021 ',GETDATE(), GETDATE(),NULL),
(N'RƯỢU BRANDY',N'Brandy là một loại rượu chưng cất được sản xuất bằng cách chưng cất rượu vang. Brandy thường chứa 35–60% độ cồn (70–120 chứng nhận Hoa Kỳ) ',GETDATE(), GETDATE(),NULL),
(N'RƯỢU VANG NHẬP KHẨU',N'Rượu vang là một loại thức uống có cồn được lên men từ nước nho. Sự cân bằng hóa học tự nhiên cho phép nho lên men không cần thêm các loại đường, axit, enzym, ...',GETDATE(), GETDATE(),NULL),
(N'RƯỢU BISQUIT',N'Rượu Bisquit XO có vị đậm đà, lan tỏa toàn thân và tuyệt mịn, Rượu Bisquit XO mời bạn khám phá một cốt lõi của gỗ khi dùng kèm khói thuốc lá - ca cao –kẹo ',GETDATE(), GETDATE(),NULL)
SELECT *FROM dbo.Catalogy
INSERT INTO dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Courvoisier VSOP Cognac',       -- ProductName - nvarchar(50)
    N'Courvoisier VSOP được làm đặc biệt từ grande champagne và petite champagne, là loại nho chất lượng nhất của vùng Cognac. Chúng được ủ từ 8 -12 năm trong các thùng gỗ sồi.',       -- Description - nvarchar(255)
    1100000,      -- PurchasePrice - money
    NULL,      -- Price - money
    100,         -- Quantity - int
    N'8-12 năm',       -- Vintage - nvarchar(50)
    N'vang01.jpg',       -- Image - nchar(50)
    N'Pháp',       -- Region - nvarchar(50)
    700,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    1          -- CatalogyId - int
    )
INSERT INTO dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Royal Salute 21 years old',       -- ProductName - nvarchar(50)
    N'Trong ấn bản đầu tiên của bộ sưu tập mới nổi bật kỷ niệm thế giới thời trang cao cấp, Royal Salute tự hào được hợp tác với ngôi sao đang lên của thời trang Anh,',       -- Description - nvarchar(255)
    4500000,      -- PurchasePrice - money
    NULL,      -- Price - money
    100,         -- Quantity - int
    N'21 năm',       -- Vintage - nvarchar(50)
    N'h02.jpg',       -- Image - nchar(50)
    N'Scotland',       -- Region - nvarchar(50)
    700,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    2          -- CatalogyId - int
    )
	INSERT INTO dbo.Product
	(
	    ProductName,
	    Description,
	    PurchasePrice,
	    Price,
	    Quantity,
	    Vintage,
	    Image,
	    Region,
	    Capacity,
	    CreateDate,
	    ModifiedDate,
	    CatalogyId
	)
	VALUES
	(   N'Rượu Macallan 12 YO Double Cask',       -- ProductName - nvarchar(50)
	    N'The Macallan là Dòng rượu Whisky mạch nha đơn cất của Scotland (Single Malt Scotch Whisky) . Nó là loại Whisky đặc biệt được sản xuất từ một loại Malt duy nhất ( Mạch nha ), từ lò chưng cất rượu ở "Thánh địa The Macallan"',       -- Description - nvarchar(255)
	    1950000,      -- PurchasePrice - money
	    NULL,      -- Price - money
	    10,         -- Quantity - int
	    N'12 năm',       -- Vintage - nvarchar(50)
	    N'h03.jpg',       -- Image - nchar(50)
	    N'Scotland',       -- Region - nvarchar(50)
	    700,         -- Capacity - int
	    GETDATE(), -- CreateDate - datetime
	    GETDATE(), -- ModifiedDate - datetime
	    3        -- CatalogyId - int
	    )
INSERT INTO dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Rượu Hổ Sứ Yamaki - Hổ Xanh Hộp Gỗ',       -- ProductName - nvarchar(50)
    N'Hổ là một loài động vật biểu tượng cho sức mạnh, sự oai linh, uy quyền, thể hiện đẳng cấp vượt trội hơn hẳn so với những loài vật khác, xứng danh là chúa Sơn lâm. Vì thế ý nghĩa biểu tượng hổ trong nhà chính là sự biểu tượng cho quyền lực, sức khỏe, ',       -- Description - nvarchar(255)
    1200000,      -- PurchasePrice - money
    NULL,      -- Price - money
    5,         -- Quantity - int
    N'2 năm',       -- Vintage - nvarchar(50)
    N'h04.jpg',       -- Image - nchar(50)
    N'Nhật',       -- Region - nvarchar(50)
    750,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    4          -- CatalogyId - int
    )
INSERT INTO dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Penfolds Koonunga Hill Shiraz',       -- ProductName - nvarchar(50)
    N'Kể từ năm 1844, Penfolds đã đóng một vai trò quan trọng trong sự phát triển của ngành sản xuất rượu vang, dựa trên những thử nghiệm, sự tìm tòi và chất lượng không thể chê vào đâu được. Những nhà sản xuất rượu có dòng dõi lâu đời ',       -- Description - nvarchar(255)
    680000,      -- PurchasePrice - money
    NULL,      -- Price - money
    100,         -- Quantity - int
    N'5 năm',       -- Vintage - nvarchar(50)
    N'h05.jpg',       -- Image - nchar(50)
    N'Autralia',       -- Region - nvarchar(50)
    750,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    5          -- CatalogyId - int
    ),
	(   N'Hill Shiraz Cabernet Sauvignon',       -- ProductName - nvarchar(50)
    N'Kể từ năm 1844, Penfolds đã đóng một vai trò quan trọng trong sự phát triển của ngành sản xuất rượu vang, dựa trên những thử nghiệm, sự tìm tòi và chất lượng không thể chê vào đâu được. Những nhà sản xuất rượu có dòng dõi lâu đời ',       -- Description - nvarchar(255)
    980000,      -- PurchasePrice - money
    NULL,      -- Price - money
    100,         -- Quantity - int
    N'5 năm',       -- Vintage - nvarchar(50)
    N'h05.jpg',       -- Image - nchar(50)
    N'Autralia',       -- Region - nvarchar(50)
    750,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    1          -- CatalogyId - int
    )
INSERT INTO	dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Vang Mỹ Opus ONE 2016',       -- ProductName - nvarchar(50)
    N'Opus One thưởng thức cho chất chát tròn vị, êm dịu, độ axit cân bằng, thanh lịch đan xen với mùi anh đào tươi và vị của socola đen. Cổ họng sẽ còn đọng lại chút vị của socola đen và đinh hương sau khi uống hết. Opus One là dòng vang cao cấp hàng đầu của Mỹ và chỉ dành 20% cho việc xuất khẩu và chủ yếu xuất ra thị trường Châu Âu.  Được sản xuất theo phong cách vùng Bordeaux, Pháp – Đó là sự pha trộn tinh tế của các loại nho Cabernet Sauvigon, Merlot, Cabernet Franc và Petit Verdot. Nhãn chai Opus One chính là biểu tượng của sự hợp tác giữa 2 người đàn ông vĩ đại trong ngành rượu vang, đó là chủ Lâu đài Mouton Rothschild của Bordeaux – Baron Philippe de Rothschild và nhà làm rượu nổi tiếng nhất Napa Valley Robert Mondavi. Tên gọi Opus One là từ được ghép bởi chữ Opus – có nguồn gốc từ tiếng Latin và One – từ tiếng Anh là một, Opus One có nghĩa là Một tác phẩm âm nhạc vĩ đại.',       -- Description - ntext
    12200000,      -- PurchasePrice - money
    NULL,      -- Price - money
    10,         -- Quantity - int
    N'5 năm',       -- Vintage - nvarchar(50)
    N'vang01.jpg',       -- Image - nchar(50)
    N'Mỹ',       -- Region - nvarchar(50)
    750,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    6          -- CatalogyId - int
    )
INSERT INTO dbo.Product
(
    ProductName,
    Description,
    PurchasePrice,
    Price,
    Quantity,
    Vintage,
    Image,
    Region,
    Capacity,
    CreateDate,
    ModifiedDate,
    CatalogyId
)
VALUES
(   N'Vang Red Cabernet Sauvignon',       -- ProductName - nvarchar(50)
    N'Cherry đỏ, bó hoa cổ điển của các loại gia vị truyền thống được tìm thấy trong các loại rượu vang Cabernet, một sắc thái của bạc hà, kèm theo hương vị của các loại thảo mộc và một chút thực vật, tạo ra một cảm giác vani sống động trong miệng, chạm dễ chịu của mận chín và trái cây, blackcurrant, cân bằng sau đó kết thúc với một hương thơm nhẹ nhàng.',       -- Description - ntext
    410000,      -- PurchasePrice - money
    NULL,      -- Price - money
    100,         -- Quantity - int
    N'2 năm',       -- Vintage - nvarchar(50)
    N'vang02.jpg',       -- Image - nchar(50)
    N'Mỹ',       -- Region - nvarchar(50)
    750,         -- Capacity - int
    GETDATE(), -- CreateDate - datetime
    GETDATE(), -- ModifiedDate - datetime
    6          -- CatalogyId - int
    )
INSERT INTO	dbo.Blog
(
    Title,
    Content,
    Image,
    CreateDate,
    ModifiedDate
)
VALUES
(   N'Nguồn gốc lịch sử rượu Meukow Cognac',       -- Title - nvarchar(50)
	N'Rượu ngoại Meukow thuộc dòng rượu Cognac nổi tiếng của Pháp, trên thế giới hiện nay có rất nhiều nơi sản xuất dòng rượu Cognac. Nhưng chỉ có đất đai, khí hậu của vùng Cognac của Pháp mới tạo ra được những trái nho đặc sắc để làm ra rượu Cognac thượng hạng.Với những mẻ rượu đầu tiên được chưng cất từ nằm 1947 - cho đến nay nguồn gốc lịch sử Cognac Meukow đã có bề dày lịch sử phát triển thương hiệu cũng như chất lượng sản phẩm . Nguồn gốc lịch sử rượu Meukow Cognac Nguồn gốc lịch sử rượu Cognac Meukow Nguồn gốc lịch sử rượu Cognac Meukow bắt đầu khi một quý tộc người Ailen có tên Richard Hennessy bắt đầu khởi nghiệp tại Cognac, Pháp vào năm 1765. Mảnh đất nơi ông khởi nghiệp sau đó thuộc về sở hữu của Hennessy do những công trạng của ông này đối với vua Louis XV. Năm 1794, Ông bắt đầu bán rượu sang thị trường Mỹ. Hennessy sau đó giới thiệu rượu mang nhãn hiệu Jean Fillioux. Năm 1813, công ty chính thức có tên là Jas Hennessy & Co. Thương hiệu Hennessy trở nên phổ biến trong tầng lớp quý tộc. Năm 1840, Hennessy chính thức thành lập trụ sở chính tại London, doanh số rượu xuất khẩu mang lại 90% tổng lợi nhuận của công ty. Năm 1864, nhà máy sản xuất vỏ chai rượu chính thức đi vào hoạt động. Nhãn hiệu Hennessy được đăng ký độc quyền. Ông Maurice Hennessy thiết lập hệ thống phân loại rượu cognac vào năm 1865. Năm 1992 là một mốc rất quan trọng. Thời điểm đó đánh dấu 120 năm chai rượu Hennessy XO đầu tiên được chuyển tới châu Á. Tại thị trấn Cognac, một tòa nhà mang tên Quais Hennessy được xây dựng với những vật liệu chỉ dùng trong sản xuất rượu cognac như đá vôi, đồng, gỗ, kính. Nguồn gốc lịch sử rượu Meukow Cognac Phân loại rượu Cognac Meukow Cognac Meukow V.S Meukow V.S được làm chưng cất từ vang trắng ủ bằng các giống nho trên. Sau chưng cất sẽ được cho vào các thùng gỗ sồi quý của Pháp là Limousin hay Troncais. Những thùng gỗ sồi này đã được đốt bên trong để phần cháy xém gần thành than đó góp phần tạo nên màu vàng óng ánh đỏ cho rượu sau mấy năm ngâm trong thùng. Meukow VSOP Sự êm dịu lạ thường của Meukow VSOP đặc trưng của các lọai trái cây được lựa chọn kĩ lưỡng sau đó ủ lên men và chưng cất để có một thứ rượu có nồng độ cao, có tính ưu việt hơn các loại rượu được chưng cất từ ngũ cốc như Vodka của người Nga hay Sochiu của người Nhật Bản. Có Mùi vị của trái óc chó , quả phỉ hương, hạt dẻ và vanilla được sắp sếp một cách “hòa thuận” và mang sắc thái êm dịu mỗi khi ta nhấp từng ngụm rượu. Meukow XO Cognac Là một thứ rượu mạnh được làm từ quả nho. Sự cháy bỏng và trang nhã- biểu tượng không đối thủ của con báoVàng biểu tả sự hài hòa đặc trưng nhất định của dòng Cognac, mang hương thơm của trái cây qua 2 lần chưng cất rồi được ủ lâu năm thông qua quá trình pha trộn thủ công tinh tế . Nguồn gốc lịch sử rượu Meukow Cognac Không chỉ nổi tiếng với các dòng rượu chất lượng, tinh tế mà còn nổi tiếng bởi nguồn gốc lịch sử rượu Cognac Meukow lâu đời, mang lại cho hãng không ít các huy chương về rượu : Huy chương Vàng tại Cuộc thi Quốc tế Rượu Paris 2002  và Huy chương Vàng cuộc thi Quốc tế Rượu London 2004. Không những vậy Cựu chủ tịch của Cộng Hòa Dân Chủ Nhân Dân Triều Tiên trước đây cũng là một người yêu thích loại rượu này. Ông là thượng khách của Hennessy trong một thập kỷ. Không thể phủ nhận sự thành công to lớn của dòng rượu này.',
    N'h100.jpg',       -- Image - nchar(50)
    GETDATE(), -- CreateDate - datetime
    GETDATE()  -- ModifiedDate - datetime
    )
INSERT INTO dbo.Blog
(
    Title,
    Content,
    Image,
    CreateDate,
    ModifiedDate
)
VALUES
(   N'Nguồn gốc lịch sử rượu Baron Otard',       -- Title - nvarchar(50)
    N'Thương hiệu Otard có lẽ là hãng rượu ngoại mà không có quý ông đam mê rượu mà không biết tới. Hiện dòng Baron Otard đang được thế giới và Việt Nam cực kỳ ưa chuộng. Nhờ vào những năm tháng để làm nên nguồn gốc lịch sử rượu Baron Otard như bây giờ. Hãy cùng chúng tôi quay ngược thời gian đi tìm những giọt rượu quý.',       -- Content - ntext
    N'h101.jpg',       -- Image - nchar(50)
    GETDATE(), -- CreateDate - datetime
    GETDATE()  -- ModifiedDate - datetime
    )
INSERT INTO dbo.Blog
(
    Title,
    Content,
    Image,
    CreateDate,
    ModifiedDate
)
VALUES
(   N'Nguồn gốc lịch sử rượu Courvoisier',       -- Title - nvarchar(50)
    N'Courvoisier là nhà sản xuất cognac duy nhất kiểm soát toàn bộ quy trình từ thu hoạch nho cho đến đóng chai bằng cách hợp tác với các nhà sản xuất nhỏ trong vùng, đây là những người đã cung cấp nho cho hãng từ thế hệ này qua thế hệ khác. Như vậy, họ có thể đảm bảo luôn luôn giữ được chất lượng hảo hạng. Mục đích chính là làm sao pha chế cognac mà vẫn giữ được hương vị như cũ qua các năm, đây là những hương vị hiếm có so với các nhà sản xuất khác – những người tạo ra các loại rượu pha chế khác nhau theo từng',       -- Content - ntext
    N'h102.jpg',       -- Image - nchar(50)
    GETDATE(), -- CreateDate - datetime
    GETDATE()  -- ModifiedDate - datetime
    )
SELECT *FROM dbo.Product
INSERT INTO dbo.OrderDetails
(
    OrderId,
    ProductId,
    Quantity,
    Discount
)
VALUES
(1,1,1,0),
(2,2,1,0),
(3,3,1,0),
(4,4,2,0),
(4,5,5,0)


SELECT *FROM dbo.[Order]
SELECT *FROM dbo.[User]
SELECT *FROM dbo.OrderDetails
SELECT *FROM dbo.Blog
SELECT *FROM dbo.Catalogy

