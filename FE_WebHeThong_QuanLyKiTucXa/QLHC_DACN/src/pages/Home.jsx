import React, { useState, useEffect } from "react";
import "@react-pdf-viewer/core/lib/styles/index.css";
import { Worker, Viewer } from "@react-pdf-viewer/core"; // Đảm bảo import đúng

const Home = () => {
  const [thongBaos, setThongBaos] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [selectedThongBao, setSelectedThongBao] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");  // Thêm state để lưu từ khóa tìm kiếm

  useEffect(() => {
    const fetchThongBaos = async () => {
      try {
        const response = await fetch("https://localhost:7257/api/ThongBao");
        if (!response.ok) {
          throw new Error("Không thể tải danh sách thông báo");
        }
        const data = await response.json();
        setThongBaos(data);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchThongBaos();
  }, []);

  const openModal = async (maThongBao) => {
    try {
      const response = await fetch(
        `https://localhost:7257/api/ThongBao/detail/${maThongBao}`
      );
      if (!response.ok) {
        throw new Error("Không thể tải chi tiết thông báo");
      }
      const data = await response.json();
      setSelectedThongBao(data);
      setIsModalOpen(true);
    } catch (error) {
      console.error(error.message);
    }
  };

  const closeModal = () => {
    setIsModalOpen(false);
    setSelectedThongBao(null);
  };

  // Hàm xử lý tìm kiếm
  const handleSearch = async () => {
    try {
      const response = await fetch(`https://localhost:7257/api/ThongBao/search?tieuDe=${searchTerm}`);
      if (!response.ok) {
        throw new Error("Không thể tìm kiếm thông báo");
      }
      const data = await response.json();
      setThongBaos(data);  // Cập nhật lại danh sách thông báo với kết quả tìm kiếm
    } catch (error) {
      setError(error.message);
    }
  };

  return (
    <div className="bg-gray-100">
      {/* Header */}
      <div className="container mx-auto flex items-center justify-between p-4">
        {/* Logo Section */}
        <a href="/" className="flex-shrink-0">
          <img
            src="src/assets/Images/logo-huit-xanh.png"
            alt="Logo"
            className="h-16 w-auto"
          />
        </a>
        {/* Title Section */}
        <div className="flex flex-col justify-center text-center">
          <h1 className="text-xl font-bold text-blue-600">
            TRƯỜNG ĐẠI HỌC CÔNG THƯƠNG TP.HỒ CHÍ MINH
          </h1>
          <h2 className="text-2xl font-medium text-red-500">
            TRUNG TÂM KÝ TÚC XÁ SINH VIÊN
          </h2>
        </div>
      </div>

      {/* Banner */}
      <div className="bg-blue-600 text-white">
        <div className="container mx-auto flex items-center justify-between py-2">
          <div className="flex items-center">
            <a href="/" className="text-white hover:text-gray-300 mr-6">
              Giới thiệu
            </a>
            <a href="/" className="text-white hover:text-gray-300 mr-6">
              Giảng viên
            </a>
            <a href="/" className="text-white hover:text-gray-300 mr-6">
              Thông báo
            </a>
            <a href="/" className="text-white hover:text-gray-300">
              Sức khỏe
            </a>
          </div>
          <div className="flex items-center">
            <input
              type="text"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}  // Lắng nghe sự thay đổi trong ô tìm kiếm
              placeholder="Nhập từ khóa cần tìm"
              className="px-4 py-2 text-black rounded-l-md"
            />
            <button
              className="bg-blue-700 text-white px-4 py-2 rounded-r-md hover:bg-blue-500"
              onClick={handleSearch}  // Gọi hàm tìm kiếm khi nhấn nút
            >
              <span className="font-bold">Tìm kiếm</span>
            </button>
          </div>
        </div>
      </div>
      <div className="container mx-auto flex items-center justify-between ">
        {/* Logo Section */}
        <a href="/" className="flex-shrink-0 w-full">
          <img
            src="src/assets/Images/banner.png"
            alt="Banner"
            className="w-full h-21" // Đặt chiều rộng full và chiều cao tự động để giữ tỷ lệ
          />
        </a>
      </div>


      {/* Danh sách thông báo */}
      <section className="container mx-auto mt-8">
        <h3 className="text-xl font-bold mb-4 text-blue-600">THÔNG BÁO</h3>
        <hr className="my-4 border-t-2 border-gray-300" />
        {loading && <p>Đang tải...</p>}
        {error && <p className="text-red-500">{error}</p>}

        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div className="col-span-2">
            {/* Danh sách thông báo */}
            {thongBaos.map((thongBao) => (
              <div
                key={thongBao.maThongBao}
                className="bg-white shadow-md rounded-lg overflow-hidden flex items-center cursor-pointer mb-4"
                onClick={() => openModal(thongBao.maThongBao)}
              >
                <img
                  src="src/assets/Images/anhthongbao.png"
                  alt="Thumbnail"
                  className="w-32 h-32 object-cover"
                />
                <div className="p-4 flex-1">
                  <h4 className="text-lg font-semibold">{thongBao.tieuDe}</h4>
                  <p className="text-gray-600 text-sm">
                    Ngày đăng:{" "}
                    {new Date(thongBao.ngayTao).toLocaleDateString("vi-VN")}
                  </p>
                  <p className="text-gray-700">{thongBao.moTa}</p>
                  {thongBao.noiDung && (
                    <p className="text-gray-800 text-sm mt-2">
                      {thongBao.noiDung}
                    </p>
                  )}
                </div>
              </div>
            ))}
          </div>

          {/* Cột phụ - Thông báo mới và Chuyên trang */}
          <div className="col-span-1">
            {/* Danh sách các chuyên trang */}
            <div className="mb-8">
              <h3 className="text-xl font-bold mb-4 text-red-600">
                CHUYÊN TRANG THÔNG BÁO
              </h3>
              <hr className="my-4 border-t-2 border-gray-300" />
              {/* Danh sách chuyên trang */}
              <ul className="space-y-4">
                <li className="hover:underline">
                  Thông báo KTX
                  <hr className="my-2 border-t-2 border-gray-200" />
                </li>
                <li className="hover:underline">
                  Kế hoạch KTX
                  <hr className="my-2 border-t-2 border-gray-200" />
                </li>
                <li className="hover:underline">
                  Thông báo HUIT
                  <hr className="my-2 border-t-2 border-gray-200" />
                </li>
                <li className="hover:underline">
                  Kế hoạch HUIT
                  <hr className="my-2 border-t-2 border-gray-200" />
                </li>
              </ul>
            </div>

            {/* Danh sách thông báo mới */}
            <div>
              <h3 className="text-xl font-bold mb-4 text-blue-700">
                THÔNG BÁO MỚI
              </h3>
              <hr className="my-4 border-t-2 border-gray-300" />
              {/* Hiển thị danh sách các tiêu đề thông báo */}
              <div className="space-y-4">
                {thongBaos.map((thongBao) => (
                  <div key={thongBao.maThongBao}>
                    <h4 className="text-lg">{thongBao.tieuDe}</h4>
                    <hr className="my-2 border-t-2" />
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Modal hiển thị chi tiết thông báo */}
      {isModalOpen && selectedThongBao && (
        <div
          className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50"
          onClick={closeModal}
        >
          <div
            className="bg-white rounded-lg shadow-lg p-6 max-w-lg w-full"
            onClick={(e) => e.stopPropagation()}
          >
            <h2 className="text-xl font-bold text-blue-600 mb-4">
              {selectedThongBao.tieuDe}
            </h2>
            <p className="text-gray-600 mb-4">
              Ngày đăng:{" "}
              {new Date(selectedThongBao.ngayDang).toLocaleDateString("vi-VN")}
            </p>

            {/* Hiển thị PDF */}
            {selectedThongBao.fileTB && (
              <div className="pdf-container" style={{ height: "500px" }}>
                <Worker
                  workerUrl={`https://unpkg.com/pdfjs-dist@3.11.174/build/pdf.worker.min.js`}
                >
                  <Viewer
                    fileUrl={`/src/assets/pdf/${selectedThongBao.fileTB}`}
                  />
                </Worker>
              </div>
            )}

            <button
              className="mt-4 bg-red-500 text-white px-4 py-2 rounded-md hover:bg-red-600"
              onClick={closeModal}
            >
              Đóng
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Home;
