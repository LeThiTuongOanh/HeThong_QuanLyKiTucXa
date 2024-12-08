import  { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import Sidebar from './components/Sidebar';
import Home from './pages/Home'; // Giả sử bạn có trang Home

const App = () => {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  const handleOpenSidebar = () => {
    setSidebarOpen(true);
  };

  const handleCloseSidebar = () => {
    setSidebarOpen(false);
  };

  return (
    <Router>
      <Header onOpenSidebar={handleOpenSidebar} />
      <Sidebar open={sidebarOpen} onClose={handleCloseSidebar} />
      <main>
        <Routes>
          <Route path="/" element={<Home />} />
          
        </Routes>
      </main>
      <Footer />
    </Router>
  );
};

export default App;
