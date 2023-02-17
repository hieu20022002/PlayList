-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th2 17, 2023 lúc 05:34 AM
-- Phiên bản máy phục vụ: 10.4.27-MariaDB
-- Phiên bản PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `qlplaylist`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `baihat`
--

CREATE TABLE `baihat` (
  `MaBaiHat` varchar(255) NOT NULL,
  `TenBaiHat` varchar(255) NOT NULL,
  `TheLoai` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `baihat`
--

INSERT INTO `baihat` (`MaBaiHat`, `TenBaiHat`, `TheLoai`) VALUES
('BH01', 'Flowers', 'R&B'),
('BH02', 'Chìm Sâu', 'Vpop'),
('BH03', 'See Tình', 'Pop'),
('BH04', 'Hãy trao cho anh', 'Pop');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `casi`
--

CREATE TABLE `casi` (
  `MaCaSi` varchar(255) NOT NULL,
  `TenCasi` varchar(255) NOT NULL,
  `GioiTinh` tinyint(1) NOT NULL,
  `NamSinh` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `casi`
--

INSERT INTO `casi` (`MaCaSi`, `TenCasi`, `GioiTinh`, `NamSinh`) VALUES
('CS01', 'Miley Ray Cyrus', 0, '1992-11-23'),
('CS02', 'All', 1, '1993-02-04');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `casi_baihat`
--

CREATE TABLE `casi_baihat` (
  `MaCaSi` varchar(255) NOT NULL,
  `MaBaiHat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `casi_baihat`
--

INSERT INTO `casi_baihat` (`MaCaSi`, `MaBaiHat`) VALUES
('CS02', 'BH01'),
('CS02', 'BH02'),
('CS02', 'BH03'),
('CS02', 'BH04');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nguoinghe`
--

CREATE TABLE `nguoinghe` (
  `MaNN` varchar(255) NOT NULL,
  `TenNN` varchar(255) NOT NULL,
  `GioiTinh` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `nguoinghe`
--

INSERT INTO `nguoinghe` (`MaNN`, `TenNN`, `GioiTinh`) VALUES
('NN01', 'Nguyễn Tuấn', 1),
('NN02', 'Lê Lan', 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `playlist`
--

CREATE TABLE `playlist` (
  `MaPlayList` varchar(255) NOT NULL,
  `TenPlayList` varchar(255) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `MaNN` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `playlist_baihat`
--

CREATE TABLE `playlist_baihat` (
  `MaPlayList` varchar(255) NOT NULL,
  `MaBaiHat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_vietnamese_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `baihat`
--
ALTER TABLE `baihat`
  ADD PRIMARY KEY (`MaBaiHat`);

--
-- Chỉ mục cho bảng `casi`
--
ALTER TABLE `casi`
  ADD PRIMARY KEY (`MaCaSi`);

--
-- Chỉ mục cho bảng `casi_baihat`
--
ALTER TABLE `casi_baihat`
  ADD PRIMARY KEY (`MaCaSi`,`MaBaiHat`),
  ADD KEY `MaBaiHat` (`MaBaiHat`);

--
-- Chỉ mục cho bảng `nguoinghe`
--
ALTER TABLE `nguoinghe`
  ADD PRIMARY KEY (`MaNN`);

--
-- Chỉ mục cho bảng `playlist`
--
ALTER TABLE `playlist`
  ADD PRIMARY KEY (`MaPlayList`),
  ADD KEY `MaNN` (`MaNN`);

--
-- Chỉ mục cho bảng `playlist_baihat`
--
ALTER TABLE `playlist_baihat`
  ADD PRIMARY KEY (`MaPlayList`,`MaBaiHat`),
  ADD KEY `MaBaiHat` (`MaBaiHat`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `casi_baihat`
--
ALTER TABLE `casi_baihat`
  ADD CONSTRAINT `casi_baihat_ibfk_1` FOREIGN KEY (`MaCaSi`) REFERENCES `casi` (`MaCaSi`),
  ADD CONSTRAINT `casi_baihat_ibfk_2` FOREIGN KEY (`MaBaiHat`) REFERENCES `baihat` (`MaBaiHat`);

--
-- Các ràng buộc cho bảng `playlist`
--
ALTER TABLE `playlist`
  ADD CONSTRAINT `playlist_ibfk_1` FOREIGN KEY (`MaNN`) REFERENCES `nguoinghe` (`MaNN`);

--
-- Các ràng buộc cho bảng `playlist_baihat`
--
ALTER TABLE `playlist_baihat`
  ADD CONSTRAINT `playlist_baihat_ibfk_1` FOREIGN KEY (`MaPlayList`) REFERENCES `playlist` (`MaPlayList`),
  ADD CONSTRAINT `playlist_baihat_ibfk_2` FOREIGN KEY (`MaBaiHat`) REFERENCES `baihat` (`MaBaiHat`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
