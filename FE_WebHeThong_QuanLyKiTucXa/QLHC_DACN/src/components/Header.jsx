import { Link } from "react-router-dom";

const Header = ({ onOpenSidebar }) => {
  return (
    <header className="bg-blue-900 text-white p-4 flex items-center justify-between max-w-full">
      <button onClick={onOpenSidebar} className="text-white text-l">
        <span className="material-icons">Menu</span>
      </button>
      <h1 className="text-l font-semibold">HUIT | Lãnh đạo | Khoa viện| Phòng ban| Trung tâm | Các chuyên trang | Doanh nghiệp</h1>
      <div className="flex space-x-4">
        <Link to="/login" className="text-white hover:text-gray-200 text-l">
          Văn bản quy định
        </Link>
        <Link to="/logout" className="text-white hover:text-gray-200 text-l">
          Hỏi đáp
        </Link>
        <Link to="/change-password" className="text-white hover:text-gray-200 text-l">
          Liên hệ
        </Link>
      </div>
    </header>
  );
};

export default Header;
