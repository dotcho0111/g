-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Ápr 14. 09:54
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `20230412`
--
CREATE DATABASE IF NOT EXISTS `20230412` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `20230412`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `megrendeles`
--

CREATE TABLE `megrendeles` (
  `id` int(11) NOT NULL,
  `datum` date NOT NULL,
  `email` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `rendelesek_szama` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `raktar`
--

CREATE TABLE `raktar` (
  `id` int(11) NOT NULL,
  `cikkszam` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `megnevezes` varchar(60) COLLATE utf8_hungarian_ci NOT NULL,
  `ar` int(11) NOT NULL,
  `mennyiseg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `raktar`
--

INSERT INTO `raktar` (`id`, `cikkszam`, `megnevezes`, `ar`, `mennyiseg`) VALUES
(1, 'P001', 'Fehér póló XXL', 3200, -2),
(2, 'P002', 'Fehér póló XL', 1800, -50),
(3, 'P003', 'Fehér póló L', 2200, -41),
(4, 'P004', 'Fehér póló M', 2500, 51),
(5, 'P005', 'Fehér póló S', 3100, -12),
(6, 'P006', 'Fekete póló XXL', 4000, -2),
(7, 'P007', 'Fekete póló XL', 1900, 17),
(8, 'P008', 'Fekete póló L', 2300, 5),
(9, 'P009', 'Fekete póló M', 2700, -72),
(10, 'P010', 'Fekete póló S', 2400, -43),
(11, 'P011', 'Piros póló XXL', 2000, -23),
(12, 'P012', 'Piros póló XL', 2200, -40),
(13, 'P013', 'Piros póló L', 3000, -2),
(14, 'P014', 'Piros póló M', 3200, -43),
(15, 'P015', 'Piros póló S', 1700, 10),
(16, 'N001', 'Fekete nadrág 54', 10000, -16),
(17, 'N002', 'Fekete nadrág 52', 11000, -59),
(18, 'N003', 'Fekete nadrág 50', 12000, 2),
(19, 'N004', 'Fekete nadrág 58', 11000, 50),
(20, 'N005', 'Szürke nadrág 54', 10000, -6),
(21, 'N006', 'Szürke nadrág 52', 11000, -65),
(22, 'N007', 'Szürke nadrág 50', 12000, 5),
(23, 'N008', 'Szürke nadrág 58', 10000, -65),
(24, 'B001', 'Baseball sapka fekete', 1000, -9),
(25, 'B002', 'Baseball sapka fehér', 900, -23),
(26, 'B003', 'Baseball sapka piros', 800, -41),
(27, 'S001', 'Stresszlabda kék', 800, 22),
(28, 'S002', 'Stresszlabda piros', 700, -1),
(29, 'S003', 'Stresszlabda sárga', 600, -27),
(30, 'S004', 'Stresszlabda zöld', 500, 0),
(31, 'BG01', 'Bögre kék', 1000, -15),
(32, 'BG02', 'Bögre piros', 1200, 15),
(33, 'BG03', 'Bögre sárga', 1100, -74),
(34, 'BG04', 'Bögre zöld', 1000, -18),
(35, 'K001', 'Kitűző kék', 500, -3),
(36, 'K002', 'Kitűző piros', 400, 0),
(37, 'K003', 'Kitűző sárga', 600, -23),
(38, 'K004', 'Kitűző kék', 500, -17),
(39, 'P001', 'Fehér póló XXL', 3200, -2),
(40, 'P002', 'Fehér póló XL', 1800, -50),
(41, 'P003', 'Fehér póló L', 2200, -41),
(42, 'P004', 'Fehér póló M', 2500, 51),
(43, 'P005', 'Fehér póló S', 3100, -12),
(44, 'P006', 'Fekete póló XXL', 4000, -2),
(45, 'P007', 'Fekete póló XL', 1900, 17),
(46, 'P008', 'Fekete póló L', 2300, 5),
(47, 'P009', 'Fekete póló M', 2700, -72),
(48, 'P010', 'Fekete póló S', 2400, -43),
(49, 'P011', 'Piros póló XXL', 2000, -23),
(50, 'P012', 'Piros póló XL', 2200, -40),
(51, 'P013', 'Piros póló L', 3000, -2),
(52, 'P014', 'Piros póló M', 3200, -43),
(53, 'P015', 'Piros póló S', 1700, 10),
(54, 'N001', 'Fekete nadrág 54', 10000, -16),
(55, 'N002', 'Fekete nadrág 52', 11000, -59),
(56, 'N003', 'Fekete nadrág 50', 12000, 2),
(57, 'N004', 'Fekete nadrág 58', 11000, 50),
(58, 'N005', 'Szürke nadrág 54', 10000, -6),
(59, 'N006', 'Szürke nadrág 52', 11000, -65),
(60, 'N007', 'Szürke nadrág 50', 12000, 5),
(61, 'N008', 'Szürke nadrág 58', 10000, -65),
(62, 'B001', 'Baseball sapka fekete', 1000, -9),
(63, 'B002', 'Baseball sapka fehér', 900, -23),
(64, 'B003', 'Baseball sapka piros', 800, -41),
(65, 'S001', 'Stresszlabda kék', 800, 22),
(66, 'S002', 'Stresszlabda piros', 700, -1),
(67, 'S003', 'Stresszlabda sárga', 600, -27),
(68, 'S004', 'Stresszlabda zöld', 500, 0),
(69, 'BG01', 'Bögre kék', 1000, -15),
(70, 'BG02', 'Bögre piros', 1200, 15),
(71, 'BG03', 'Bögre sárga', 1100, -74),
(72, 'BG04', 'Bögre zöld', 1000, -18),
(73, 'K001', 'Kitűző kék', 500, -3),
(74, 'K002', 'Kitűző piros', 400, 0),
(75, 'K003', 'Kitűző sárga', 600, -23),
(76, 'K004', 'Kitűző kék', 500, -17),
(77, 'P001', 'Fehér póló XXL', 3200, -2),
(78, 'P002', 'Fehér póló XL', 1800, -50),
(79, 'P003', 'Fehér póló L', 2200, -41),
(80, 'P004', 'Fehér póló M', 2500, 51),
(81, 'P005', 'Fehér póló S', 3100, -12),
(82, 'P006', 'Fekete póló XXL', 4000, -2),
(83, 'P007', 'Fekete póló XL', 1900, 17),
(84, 'P008', 'Fekete póló L', 2300, 5),
(85, 'P009', 'Fekete póló M', 2700, -72),
(86, 'P010', 'Fekete póló S', 2400, -43),
(87, 'P011', 'Piros póló XXL', 2000, -23),
(88, 'P012', 'Piros póló XL', 2200, -40),
(89, 'P013', 'Piros póló L', 3000, -2),
(90, 'P014', 'Piros póló M', 3200, -43),
(91, 'P015', 'Piros póló S', 1700, 10),
(92, 'N001', 'Fekete nadrág 54', 10000, -16),
(93, 'N002', 'Fekete nadrág 52', 11000, -59),
(94, 'N003', 'Fekete nadrág 50', 12000, 2),
(95, 'N004', 'Fekete nadrág 58', 11000, 50),
(96, 'N005', 'Szürke nadrág 54', 10000, -6),
(97, 'N006', 'Szürke nadrág 52', 11000, -65),
(98, 'N007', 'Szürke nadrág 50', 12000, 5),
(99, 'N008', 'Szürke nadrág 58', 10000, -65),
(100, 'B001', 'Baseball sapka fekete', 1000, -9),
(101, 'B002', 'Baseball sapka fehér', 900, -23),
(102, 'B003', 'Baseball sapka piros', 800, -41),
(103, 'S001', 'Stresszlabda kék', 800, 22),
(104, 'S002', 'Stresszlabda piros', 700, -1),
(105, 'S003', 'Stresszlabda sárga', 600, -27),
(106, 'S004', 'Stresszlabda zöld', 500, 0),
(107, 'BG01', 'Bögre kék', 1000, -15),
(108, 'BG02', 'Bögre piros', 1200, 15),
(109, 'BG03', 'Bögre sárga', 1100, -74),
(110, 'BG04', 'Bögre zöld', 1000, -18),
(111, 'K001', 'Kitűző kék', 500, -3),
(112, 'K002', 'Kitűző piros', 400, 0),
(113, 'K003', 'Kitűző sárga', 600, -23),
(114, 'K004', 'Kitűző kék', 500, -17),
(115, 'P001', 'Fehér póló XXL', 3200, -2),
(116, 'P002', 'Fehér póló XL', 1800, -50),
(117, 'P003', 'Fehér póló L', 2200, -41),
(118, 'P004', 'Fehér póló M', 2500, 51),
(119, 'P005', 'Fehér póló S', 3100, -12),
(120, 'P006', 'Fekete póló XXL', 4000, -2),
(121, 'P007', 'Fekete póló XL', 1900, 17),
(122, 'P008', 'Fekete póló L', 2300, 5),
(123, 'P009', 'Fekete póló M', 2700, -72),
(124, 'P010', 'Fekete póló S', 2400, -43),
(125, 'P011', 'Piros póló XXL', 2000, -23),
(126, 'P012', 'Piros póló XL', 2200, -40),
(127, 'P013', 'Piros póló L', 3000, -2),
(128, 'P014', 'Piros póló M', 3200, -43),
(129, 'P015', 'Piros póló S', 1700, 10),
(130, 'N001', 'Fekete nadrág 54', 10000, -16),
(131, 'N002', 'Fekete nadrág 52', 11000, -59),
(132, 'N003', 'Fekete nadrág 50', 12000, 2),
(133, 'N004', 'Fekete nadrág 58', 11000, 50),
(134, 'N005', 'Szürke nadrág 54', 10000, -6),
(135, 'N006', 'Szürke nadrág 52', 11000, -65),
(136, 'N007', 'Szürke nadrág 50', 12000, 5),
(137, 'N008', 'Szürke nadrág 58', 10000, -65),
(138, 'B001', 'Baseball sapka fekete', 1000, -9),
(139, 'B002', 'Baseball sapka fehér', 900, -23),
(140, 'B003', 'Baseball sapka piros', 800, -41),
(141, 'S001', 'Stresszlabda kék', 800, 22),
(142, 'S002', 'Stresszlabda piros', 700, -1),
(143, 'S003', 'Stresszlabda sárga', 600, -27),
(144, 'S004', 'Stresszlabda zöld', 500, 0),
(145, 'BG01', 'Bögre kék', 1000, -15),
(146, 'BG02', 'Bögre piros', 1200, 15),
(147, 'BG03', 'Bögre sárga', 1100, -74),
(148, 'BG04', 'Bögre zöld', 1000, -18),
(149, 'K001', 'Kitűző kék', 500, -3),
(150, 'K002', 'Kitűző piros', 400, 0),
(151, 'K003', 'Kitűző sárga', 600, -23),
(152, 'K004', 'Kitűző kék', 500, -17),
(153, 'P001', 'Fehér póló XXL', 3200, -2),
(154, 'P002', 'Fehér póló XL', 1800, -50),
(155, 'P003', 'Fehér póló L', 2200, -41),
(156, 'P004', 'Fehér póló M', 2500, 51),
(157, 'P005', 'Fehér póló S', 3100, -12),
(158, 'P006', 'Fekete póló XXL', 4000, -2),
(159, 'P007', 'Fekete póló XL', 1900, 17),
(160, 'P008', 'Fekete póló L', 2300, 5),
(161, 'P009', 'Fekete póló M', 2700, -72),
(162, 'P010', 'Fekete póló S', 2400, -43),
(163, 'P011', 'Piros póló XXL', 2000, -23),
(164, 'P012', 'Piros póló XL', 2200, -40),
(165, 'P013', 'Piros póló L', 3000, -2),
(166, 'P014', 'Piros póló M', 3200, -43),
(167, 'P015', 'Piros póló S', 1700, 10),
(168, 'N001', 'Fekete nadrág 54', 10000, -16),
(169, 'N002', 'Fekete nadrág 52', 11000, -59),
(170, 'N003', 'Fekete nadrág 50', 12000, 2),
(171, 'N004', 'Fekete nadrág 58', 11000, 50),
(172, 'N005', 'Szürke nadrág 54', 10000, -6),
(173, 'N006', 'Szürke nadrág 52', 11000, -65),
(174, 'N007', 'Szürke nadrág 50', 12000, 5),
(175, 'N008', 'Szürke nadrág 58', 10000, -65),
(176, 'B001', 'Baseball sapka fekete', 1000, -9),
(177, 'B002', 'Baseball sapka fehér', 900, -23),
(178, 'B003', 'Baseball sapka piros', 800, -41),
(179, 'S001', 'Stresszlabda kék', 800, 22),
(180, 'S002', 'Stresszlabda piros', 700, -1),
(181, 'S003', 'Stresszlabda sárga', 600, -27),
(182, 'S004', 'Stresszlabda zöld', 500, 0),
(183, 'BG01', 'Bögre kék', 1000, -15),
(184, 'BG02', 'Bögre piros', 1200, 15),
(185, 'BG03', 'Bögre sárga', 1100, -74),
(186, 'BG04', 'Bögre zöld', 1000, -18),
(187, 'K001', 'Kitűző kék', 500, -3),
(188, 'K002', 'Kitűző piros', 400, 0),
(189, 'K003', 'Kitűző sárga', 600, -23),
(190, 'K004', 'Kitűző kék', 500, -17);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tetelek`
--

CREATE TABLE `tetelek` (
  `rendeles_szama` int(11) NOT NULL,
  `cikkszam` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `mennyiseg` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `megrendeles`
--
ALTER TABLE `megrendeles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rendeles` (`rendelesek_szama`);

--
-- A tábla indexei `raktar`
--
ALTER TABLE `raktar`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `tetelek`
--
ALTER TABLE `tetelek`
  ADD PRIMARY KEY (`rendeles_szama`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `megrendeles`
--
ALTER TABLE `megrendeles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `raktar`
--
ALTER TABLE `raktar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=191;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `megrendeles`
--
ALTER TABLE `megrendeles`
  ADD CONSTRAINT `megrendeles_ibfk_1` FOREIGN KEY (`rendelesek_szama`) REFERENCES `tetelek` (`rendeles_szama`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
