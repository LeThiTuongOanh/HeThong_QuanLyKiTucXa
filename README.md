Thông Tin Đề Tài : Quản lý ký túc xá trường Đại Học Công Thương TP.HCM. 
Nhóm 15:
1.Thành Viên Nhóm
    1.	2001216091 - Lê Nhật Quyên
    2.	2001216014 - Lê Thị Tường Oanh
    3.	2001215849 - Huỳnh Tuấn Khang
2.Nền Tảng và công cụ sử dụng
    •	Công cụ: Visual Studio 2022 , Visual Studio Code, SQL Server 2022
    •	Cơ sở dữ liệu: SQL Server
    •	Giao diện ứng dụng: WinForms
    •	Giao diện Web (ReactJS): Xây dựng bằng ReactJS, kết nối API để xử lý dữ liệu. 
    • Ngôn ngữ : C#
    •	Back-End : Xây dựng API sử dụng  .NET Core.
3.Nghiệp Vụ
    3.1. Nhân Viên Quản Lý
        3.1.1. Quản Lý Trang Thiết Bị
            •	Thêm, xóa, sửa thông tin trang thiết bị.
            •	Lập phiếu quản lý trang thiết bị.
            •	Quản lý nhập trang thiết bị.
            •	Thống kê nhập trang thiết bị.
        3.1.2. Quản Lý Yêu Cầu Sửa Chữa
            •	Lập phiếu yêu cầu sửa chữa định kỳ.
            •	Lập phiếu yêu cầu sửa chữa từ sinh viên.
            •	Quản lý các yêu cầu sửa chữa.
            •	Thống kê số lượng thiết bị được sửa chữa theo tháng/năm.
        3.1.3. Quản Lý Dịch Vụ
            •	Lập phiếu đăng ký dịch vụ (gồm 2 loại: Căn Tin và Giặt Ủi).
            •	Lên thực đơn theo tuần của căn tin:
                o	Thuật toán: Sử dụng thuật toán di truyền để tạo thực đơn hợp lý dựa trên các chỉ số dinh dưỡng (calo, protein, carb, fat).
            •	Quản lý đăng ký dịch vụ.
            •	Thống kê dịch vụ.
        3.1.4. Quản Lý Nội Quy An Ninh
            •	Quản lý nội quy ký túc xá.
            •	Lập phiếu vi phạm.
            •	Quản lý thông tin vi phạm.
            •	Thống kê vi phạm.
            •	Lập thẻ ra vào ký túc xá.
            •	Đăng tải thông báo.
        3.1.5. Quản Lý Tài Chính
            •	Thanh toán tiền điện, nước hàng tháng.
            •	Quản lý thanh toán tiền điện, nước.
            •	Thống kê điện, nước theo tháng.
        3.1.6. Báo Cáo Thống Kê
            •	Báo cáo nội trú:
              o	Tỷ lệ sinh viên trên các tầng.
              o	Xuất danh sách sinh viên đăng ký nội trú theo năm.
            •	Báo cáo điện/nước:
              o	Tỷ lệ tiêu thụ điện giữa các tầng.
              o	Tỷ lệ tiêu thụ nước giữa các tầng.
    3.2. Nhân Viên Tuyển Sinh
        3.2.1. Đăng Ký Lưu Trú
            •	Cho phép sinh viên đăng ký thông tin cá nhân và phòng ở.
        3.2.2. Quản Lý Sinh Viên
            •	Quản lý thông tin cá nhân của sinh viên.
            •	Theo dõi lịch sử lưu trú của sinh viên.
            •	Quản lý các khoản phí đăng ký phòng.
        3.2.3. Phân Chia Phòng
            •	Phân công sinh viên vào các phòng ở phù hợp.
            •	Thuật toán: Sử dụng thuật toán K-means.
        3.2.4. Quản Lý Phòng
            •	Quản lý thông tin phòng (số phòng, trạng thái phòng, số lượng sinh viên tối đa).
            •	Theo dõi lịch sử sử dụng phòng.
    3.3. Chức Năng Website (ReactJS + API)
        3.3.1.	Xem danh sách thông báo.
        3.3.2.	Xem chi tiết thông báo.
        3.3.3.	Tìm kiếm thông báo.
4.Phân công chức năng:
   Lê Nhật Quyên:
        ＋	Quản lý yêu cầu sửa chữa , Quản lý nội quy an ninh
        ＋	Thanh toán tiền điện nước, đăng ký dịch vụ , nhập trang thiết bị , nhập nguyên liệu,lập thẻ ra vào kí túc xá ,thông kê báo cáo thu chi .
        ＋	Tạo thực đơn theo tuần 
  Lê Thị Tường Oanh:
        ＋	Đăng ký nội trú , Quản lý Phòng , Quản lý sinh viên , Quản lý thống kê trang thiết bị
        ＋	Phân Phòng
  Huỳnh Tuấn Khang:
        ＋	Tạo tài khoản Nhân Viên, Quản lý nhân viên , Quản lý thống kê dịch vụ, đăng thông báo và quản lý thống báo
        ＋	Web ký túc xá hiển thị danh sách thông báo và xem chi tiết thông báo.
5. Hướng Dẫn Cài Đặt và Khởi Chạy
5.1. Back-End API
  1.	Mở dự án API trong Visual Studio hoặc IDE bạn sử dụng.
  2.	Kiểm tra file appsettings.json:
    o	Đảm bảo cấu hình connection string đến SQL Server.
  3.	Build và chạy API.
    o	API sẽ khởi động tại 
5.2. Front-End ReactJS
  1.	Điều hướng đến thư mục dự án ReactJS.
  2.	Chạy lệnh: npm install ,npm start
  3.	Truy cập giao diện web .
5.3. WinForms
  1.	Mở dự án WinForms trên Visual Studio.
  2.	Build và chạy chương trình.
6.Hướng Dẫn Sử Dụng
  1.	Cài Đặt:
    o	Cấu hình cơ sở dữ liệu SQL Server.
    o	Import database mẫu vào SQL Server.
  2.	Khởi Chạy Ứng Dụng:
    o	Mở dự án WinForms trên Visual Studio và build chương trình.
    o	Chạy ứng dụng ASP.NET MVC để truy cập website.
  3.	Tài Khoản Mặc Định:
    o	Nhân viên quản lý: Tên Đăng Nhập: tranbinh, Mật Khẩu: Aa&081103 
    o	Nhân viên tuyển sinh: Tên Đăng Nhập: duyquoc, Mật Khẩu: duyquoc%3108
