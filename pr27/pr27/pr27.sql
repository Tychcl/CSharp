-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 02 2025 г., 23:52
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `pr27`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Afisha`
--

CREATE TABLE `Afisha` (
  `Id` int NOT NULL,
  `Theatre` int NOT NULL,
  `Film` text NOT NULL,
  `Time` text NOT NULL,
  `Price` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Theatre`
--

CREATE TABLE `Theatre` (
  `Id` int NOT NULL,
  `Name` varchar(45) NOT NULL,
  `RoomCount` int NOT NULL,
  `PlaceCount` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Theatre`
--

INSERT INTO `Theatre` (`Id`, `Name`, `RoomCount`, `PlaceCount`) VALUES
(0, 'фищфф', 12, 2);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Afisha`
--
ALTER TABLE `Afisha`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id_UNIQUE` (`Id`),
  ADD KEY `Theatre` (`Theatre`);

--
-- Индексы таблицы `Theatre`
--
ALTER TABLE `Theatre`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Afisha`
--
ALTER TABLE `Afisha`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Afisha`
--
ALTER TABLE `Afisha`
  ADD CONSTRAINT `afisha_ibfk_1` FOREIGN KEY (`Theatre`) REFERENCES `Theatre` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
