-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 14 maj 2020 kl 13:59
-- Serverversion: 10.4.11-MariaDB
-- PHP-version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `chefist`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `comments`
--

CREATE TABLE `comments` (
  `idComments` int(11) NOT NULL,
  `content` varchar(500) NOT NULL,
  `date` datetime NOT NULL,
  `User_username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tabellstruktur `comments_has_recipes`
--

CREATE TABLE `comments_has_recipes` (
  `Comments_idComments` int(11) NOT NULL,
  `Recipes_idRecipes` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tabellstruktur `cuisine`
--

CREATE TABLE `cuisine` (
  `name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumpning av Data i tabell `cuisine`
--

INSERT INTO `cuisine` (`name`) VALUES
('American'),
('BBQ'),
('Chinese'),
('Eastern-European'),
('French'),
('Germam'),
('Indian'),
('Japanese'),
('Mexican'),
('Middle-eastern'),
('Russian'),
('Scandinavian');

-- --------------------------------------------------------

--
-- Tabellstruktur `ratings`
--

CREATE TABLE `ratings` (
  `rating` decimal(11,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tabellstruktur `recipes`
--

CREATE TABLE `recipes` (
  `idRecipes` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `ingredients` varchar(2000) NOT NULL,
  `description` mediumtext NOT NULL,
  `date` datetime NOT NULL,
  `User_username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumpning av Data i tabell `recipes`
--

INSERT INTO `recipes` (`idRecipes`, `Name`, `ingredients`, `description`, `date`, `User_username`) VALUES
(1, 'Curry Udon noodles', '2-3 blocks japanese curry roux\r\n1/2 onion\r\n1/2 potato\r\n1/2 carrot\r\n2 packs pre-cooked udon noodles\r\n4 tbsp tsuyu soup stock\r\n640-760ml water\r\n1 spring onion\r\nshichimi togarashi (optional)', '1. To make your Curry Udon, start by cutting the onion, potato and carrot into small chunks before adding them to a pan filled with 120ml water per curry roux block.\r\n\r\n2. Bring the water to the boil and then simmer for 20 minutes or until the vegetables soften.\r\n\r\n3. Add 2-3 blocks of curry roux (depending on quantity of water) to the pot and allow to simmer for 10 minutes. Keep stirring until the curry sauce is thick and smooth.\r\n\r\n4. Add 4 tablespoons of tsuyu soup stock to 400ml water and boil in a separate pan to make the noodle soup.\r\n\r\n5. Boil the udon noodles in hot water for a few minutes before draining well in a colander.\r\n\r\n6. Place your cooked udon noodles in a bowl, add the noodle soup and then your curry sauce on top. Finally, garnish with sliced spring onions and serve immediately.\r\n\r\nTips and Information\r\n- To spice up your Curry Udon Noodles, add a pinch of Shichimi Togarashi spice when serving.\r\n\r\n- You can add bite size pieces of cooked chicken as well.', '2020-05-14 13:52:53', 'Crofty'),
(2, 'Onigri', '65g cooked japanese rice, 1/4 sheet nori seaweed, pinch of salt, shiso perilla leaf (optional), sesame seeds (optional)', '1. Begin by cooking the Japanese rice according to your favourite method.\r\n\r\n2. With a small amount of salt sprinkled on your hands, mould the rice into small balls or triangles approximately 8cm wide.\r\n\r\n3. Create a small well in the centre of the rice and put in your choice of ingredients. Then mould the rice with your hands around the well to cover your filling completely.\r\n\r\n4. Using a sheet of nori seaweed, wrap up your ball of rice.\r\n\r\n5. Sprinkle some sesame seeds or cut up shiso leaves to put on the rice for a little extra flavour (optional). Enjoy for a snack or during lunch.\r\n\r\nTips and Information\r\n- If you are not sure about making onigiri with your hands or handling hot rice you can use a piece of cling film to mould the rice. Alternatively, take a look at japancentre.com\'s great collection of easy-to-use rice ball moulds.\r\n- Ingredients are enough to make one onigiri. To make more, multiply the ingredient amounts by the number of onigiri you wish to make.\r\n- To learn more about Japanese rice, visit our how to page.\r\n- To learn more about Furikake Rice Seasoning, see our how to page and be inspired if you\'re looking for ways to flavour your onigiri.', '2020-05-14 13:35:48', 'Crofty'),
(3, 'Miso Ramen Soup with pakchoi and poached egg', 'ramen noodles, 1 packet\r\n1 free-range egg\r\n1 pakchoi, trimmed\r\n1 spring onion, finely chopped\r\n1 tsp chilli oil, optional\r\n1 tbsp of crispy shallots, or toasted sesame seeds\r\n\r\nmiso soup:\r\n600ml of water\r\n2 tbsp red miso paste\r\n1 tsp sesame oil\r\nlarge pinch of white pepper\r\nsea salt, to taste', '1. Put the kettle on to boil. Pour 600ml of boiling water into a saucepan. Add the ramen noodles and cook on medium heat for about a minute, or until almost cooked according to packet instructions.\r\n                                                                                                          2.In a separate little bowl, combine the red miso and steal a few tablespoons of hot water from the saucepan. Stir the miso and water together until you get a smooth runny paste.\r\n                                                                                                          3. When the noodles are almost cooked, lower the heat and stir in the miso solution, sesame oil and white pepper. Taste and adjust the seasoning with salt, if necessary.\r\n                                                                                                          4. Add the pakchoi and crack an egg straight into the simmering soup, letting them poach gently with the noodles. Cook until the pakchoi is tender and the egg whites turn opaque, scooping the hot broth over the egg to speed up the process if you like.\r\n                                                                                                          5. Carefully scoop the noodles and pakchoi into a bowl before pouring the soup and poached egg over them.\r\n                                                                                                          6. Finish with a drizzle of chill oil and a sprinkle of spring onions and crispy shallots/toasted sesame seeds if desired. Enjoy.', '2020-05-14 13:37:06', 'Crofty'),
(4, 'Maki sushi rolls', '100g sushi rice\r\n1 sheet nori seaweed\r\n2 tbsp sushi vinegar\r\nsoy sauce\r\nwasabi\r\nsushi ginger\r\nroasted white sesame seeds (optional)\r\n\r\npossible fillings\r\ntuna – sashimi grade, raw\r\nsalmon – sashimi grade, raw\r\navocado\r\ncucumber\r\ncrab sticks\r\ncanned tuna mixed with mayo\r\nprawns', '1. To make sushi rice, Japanese white rice is mixed with a special sushi rice vinegar.\r\n\r\n2. Once you have your sushi rice prepared, you will need to begin by laying out a preparation area with your makisu rolling mat.\r\n\r\n3. Place a sheet or nori on the mat and cover two thirds of one side of your nori seaweed with your sushi rice approximately 1cm high.\r\n\r\n4. Add your ingredients in a line on top of the rice in the centre. You can choose any combination of ingredients that compliment each other well. We went for salmon, salad and mayonnaise for this one.\r\n\r\n5. Now for the fun bit. Using the wooden rolling mat, start rolling up the ingredients away from you, while keeping the roll tight. The moisture from the rice will help it stick together.\r\n\r\n6. You can then cut your roll into 6-8 pieces and serve with some soy sauce, wasabi, sushi ginger and cup of sencha green tea.\r\n\r\nTips and Information\r\n- Try wrapping your sushi rolling mat with cling film before you start rolling as this will not only make the mat easier to clean after using, but helps the sticky rice from getting stuck on the mat.\r\n- It is a good idea to have a bowl of water next to you when you are making makizushi as it is important to keep your fingers wet so that the rice doesn’t stick to them. It is also a good idea to keep the knife wet when you cut it to guarantee that you get a clean cut.\r\n- You can make what’s called an Uramaki roll, or an inside out roll. This is made with the nori on the inside and the rice on the outside of the roll. Uramaki is great sprinkled with roasted white sesame seeds.\r\n- Makizushi usually come in two types, futomaki and hosomaki. Futomaki is a thick roll like the one we are making in the photos above with a selection of ingredients inside. Hosomaki is a thinner version, usually containing just one ingredient such as tuna, salmon or cucumber.\r\n- You can use any types of ingredients for sushi rolls. Many of the popular ones like California Roll (Crab Sticks, Avocado & Cucumber) and the Philadelphia Roll (Smoked Salmon, Cream Cheese & Cucumber) were both invented outside Japan.', '2020-05-14 13:42:52', 'Crofty'),
(5, 'Yakitori grilled skewers', 'chicken breast or thigh\r\nspring onions\r\n\r\nsuggested additional items:\r\nleek\r\ngreen pepper\r\npork belly slices\r\nasparagus\r\nfirm tofu, cubed\r\n\r\nsauce:\r\n1 tbsp cooking sake\r\n1 tbsp mirin\r\n3 tbsp soy sauce\r\n2 tbsp sugar\r\n1-2 tsp katakuriko potato starch, mixed with cold water\r\n\r\nshichimi pepper seasoning (optional)', '1. Let’s begin by making the sauce. Add the cooking sake, mirin and soy sauce to a pan with two tablespoons of sugar. The ratio of these ingredients can be changed to suit your taste as all Japanese yakitori chefs have their own personalised sauce recipes.\r\n\r\n2. Add a little katakuriko potato starch dissolved in water to the pan and heat the mix without boiling it before simmering gently. The katakuriko starch is useful for thickening the sauce, but this can be omitted depending on how you prefer your sauce. Allow the sauce to simmer on the stove until the volume has been reduced and it becomes thick and sticky.\r\n\r\n3. Take your sauce off the hob and leave aside while we prepare our skewers. Soak the wooden skewers in water beforehand for a few minutes to keep them from burning when we grill our yakitori.\r\n\r\n4. Make sure that you cut up your chicken into small bitesize pieces and slice your spring onion into approximately 3cm lengths. Start spearing the ingredients onto your skewers alternately so have a good mix of both chicken and spring onion. Now using a cooking brush, begin glazing the skewer ingredients with your yakitori sauce.\r\n\r\n5. The traditional method for the next step is using an open flame grill with special aromatic charcoal sourced from Wakayama prefecture in Japan called Binchotan. Of course, this may prove to be slightly hard to source, so a normal barbecue should work nicely. Start placing the skewers on the barbecue in an area with a strong, even heat.\r\n\r\n6. Keep turning the yakitori regularly so they cook evenly and brush more yakitori sauce onto the chicken each time you turn them.\r\n\r\n7. Once the chicken has cooked to a golden colour they should be ready to serve, so place them on a plate in pairs and serve with a fresh coating of yakitori sauce. You can also use a little shichimi pepper powder here for some extra spicy flavour.\r\n\r\nTips and Information\r\n- Although yakitori is traditionally made with pieces of chicken and spring onions, there are many other varieties that you can try. Other options include pieces of pork, asparagus wrapped in pork belly slices, chicken skin, chicken wings and various other vegetables to mix up with the meat. If you are feeling really adventurous, see if your local butcher has chicken hearts as these are delicious as yakitori.\r\n- If you prefer, you can purchase pre-make yakitori sauce to make things a little easier. However, it’s always fun to make the sauce too and it also enables you to make the sauce to your own personal taste preferences.\r\n- You can make vegetarian yakitori by using tofu and vegetables as a replacement for the chicken. Simply follow the recipe as normal, but use firm tofu instead. Just make sure that you do not use soft or silken tofu as it will most likely fall apart when you try to grill it.', '2020-05-14 13:44:09', 'Crofty');

-- --------------------------------------------------------

--
-- Tabellstruktur `recipes_has_cuisine`
--

CREATE TABLE `recipes_has_cuisine` (
  `Recipes_idRecipes` int(11) NOT NULL,
  `Cuisine_name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumpning av Data i tabell `recipes_has_cuisine`
--

INSERT INTO `recipes_has_cuisine` (`Recipes_idRecipes`, `Cuisine_name`) VALUES
(1, 'Japanese'),
(2, 'Japanese'),
(3, 'Japanese'),
(4, 'Japanese'),
(5, 'Japanese');

-- --------------------------------------------------------

--
-- Tabellstruktur `recipes_has_ratings`
--

CREATE TABLE `recipes_has_ratings` (
  `Recipes_idRecipes` int(11) NOT NULL,
  `Ratings_rating` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tabellstruktur `user`
--

CREATE TABLE `user` (
  `username` varchar(50) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumpning av Data i tabell `user`
--

INSERT INTO `user` (`username`, `password`, `email`) VALUES
('admin', 'admin', 'admin@email.com'),
('Crofty', 'password', 'email@email.com');

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`idComments`);

--
-- Index för tabell `comments_has_recipes`
--
ALTER TABLE `comments_has_recipes`
  ADD PRIMARY KEY (`Comments_idComments`,`Recipes_idRecipes`);

--
-- Index för tabell `cuisine`
--
ALTER TABLE `cuisine`
  ADD PRIMARY KEY (`name`);

--
-- Index för tabell `ratings`
--
ALTER TABLE `ratings`
  ADD PRIMARY KEY (`rating`);

--
-- Index för tabell `recipes`
--
ALTER TABLE `recipes`
  ADD PRIMARY KEY (`idRecipes`);

--
-- Index för tabell `recipes_has_cuisine`
--
ALTER TABLE `recipes_has_cuisine`
  ADD PRIMARY KEY (`Recipes_idRecipes`,`Cuisine_name`);

--
-- Index för tabell `recipes_has_ratings`
--
ALTER TABLE `recipes_has_ratings`
  ADD PRIMARY KEY (`Recipes_idRecipes`,`Ratings_rating`);

--
-- Index för tabell `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `comments`
--
ALTER TABLE `comments`
  MODIFY `idComments` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `recipes`
--
ALTER TABLE `recipes`
  MODIFY `idRecipes` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
