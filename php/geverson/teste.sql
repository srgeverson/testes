CREATE TABLE `imagens` (
  `id` int(11) NOT NULL,
  `nome` varchar(220) COLLATE utf8_unicode_ci NOT NULL,
  `imagem` varchar(220) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

INSERT INTO `imagens` (`id`, `nome`, `imagem`) VALUES
(1, 'Teste 1', 'cinco.png');
ALTER TABLE `imagens`
  ADD PRIMARY KEY (`id`);
ALTER TABLE `imagens`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;