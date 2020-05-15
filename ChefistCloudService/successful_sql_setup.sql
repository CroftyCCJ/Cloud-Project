DROP TABLE IF EXISTS [users];

CREATE TABLE users (
  [username] varchar(50) NOT NULL,
  [password] varchar(45) NOT NULL,
  [email] varchar(50) NOT NULL,
  PRIMARY KEY ([username])
) ;



INSERT INTO users VALUES ('admin','admin','admin@email.com'),('Crofty','password','email@email.com');

DROP TABLE IF EXISTS [cuisine];

CREATE TABLE cuisine (
  [name] varchar(45) NOT NULL,
  PRIMARY KEY ([name])
) ;




INSERT INTO cuisine VALUES ('American'),('BBQ'),('Chinese'),('Eastern-European'),('French'),('Germam'),('Indian'),('Japanese'),('Mexican'),('Middle-eastern'),('Russian'),('Scandinavian');




DROP TABLE IF EXISTS [recipes];

CREATE TABLE recipes (
  [id_recipe] int NOT NULL IDENTITY,
  [name] varchar(45) NOT NULL,
  [ingredients] varchar(2000) NOT NULL,
  [description] varchar(max) NOT NULL,
  [date] datetime2(0) NOT NULL,
  [owner] varchar(50) NOT NULL,
  PRIMARY KEY ([id_recipe])
 ,
  CONSTRAINT [fk_owner_username] FOREIGN KEY ([owner]) REFERENCES users ([username])
)  ;

CREATE INDEX [foreignkeyuser_idx] ON recipes ([owner]);



INSERT INTO recipes VALUES (1,'Curry Udon noodles','2-3 blocks japanese curry rouxrn1/2 onionrn1/2 potatorn1/2 carrotrn2 packs pre-cooked udon noodlesrn4 tbsp tsuyu soup stockrn640-760ml waterrn1 spring onionrnshichimi togarashi (optional)','1. To make your Curry Udon, start by cutting the onion, potato and carrot into small chunks before adding them to a pan filled with 120ml water per curry roux block.rnrn2. Bring the water to the boil and then simmer for 20 minutes or until the vegetables soften.rnrn3. Add 2-3 blocks of curry roux (depending on quantity of water) to the pot and allow to simmer for 10 minutes. Keep stirring until the curry sauce is thick and smooth.rnrn4. Add 4 tablespoons of tsuyu soup stock to 400ml water and boil in a separate pan to make the noodle soup.rnrn5. Boil the udon noodles in hot water for a few minutes before draining well in a colander.rnrn6. Place your cooked udon noodles in a bowl, add the noodle soup and then your curry sauce on top. Finally, garnish with sliced spring onions and serve immediately.rnrnTips and Informationrn- To spice up your Curry Udon Noodles, add a pinch of Shichimi Togarashi spice when serving.rnrn- You can add bite size pieces of cooked chicken as well.','2020-05-14 13:52:53','Crofty'),(2,'Onigri','65g cooked japanese rice, 1/4 sheet nori seaweed, pinch of salt, shiso perilla leaf (optional), sesame seeds (optional)','1. Begin by cooking the Japanese rice according to your favourite method.rnrn2. With a small amount of salt sprinkled on your hands, mould the rice into small balls or triangles approximately 8cm wide.rnrn3. Create a small well in the centre of the rice and put in your choice of ingredients. Then mould the rice with your hands around the well to cover your filling completely.rnrn4. Using a sheet of nori seaweed, wrap up your ball of rice.rnrn5. Sprinkle some sesame seeds or cut up shiso leaves to put on the rice for a little extra flavour (optional). Enjoy for a snack or during lunch.rnrnTips and Informationrn- If you are not sure about making onigiri with your hands or handling hot rice you can use a piece of cling film to mould the rice. Alternatively, take a look at japancentre.com''s great collection of easy-to-use rice ball moulds.rn- Ingredients are enough to make one onigiri. To make more, multiply the ingredient amounts by the number of onigiri you wish to make.rn- To learn more about Japanese rice, visit our how to page.rn- To learn more about Furikake Rice Seasoning, see our how to page and be inspired if you''re looking for ways to flavour your onigiri.','2020-05-14 13:35:48','Crofty'),(3,'Miso Ramen Soup with pakchoi and poached egg','ramen noodles, 1 packetrn1 free-range eggrn1 pakchoi, trimmedrn1 spring onion, finely choppedrn1 tsp chilli oil, optionalrn1 tbsp of crispy shallots, or toasted sesame seedsrnrnmiso soup:rn600ml of waterrn2 tbsp red miso pastern1 tsp sesame oilrnlarge pinch of white pepperrnsea salt, to taste','1. Put the kettle on to boil. Pour 600ml of boiling water into a saucepan. Add the ramen noodles and cook on medium heat for about a minute, or until almost cooked according to packet instructions.rn                                                                                                          2.In a separate little bowl, combine the red miso and steal a few tablespoons of hot water from the saucepan. Stir the miso and water together until you get a smooth runny paste.rn                                                                                                          3. When the noodles are almost cooked, lower the heat and stir in the miso solution, sesame oil and white pepper. Taste and adjust the seasoning with salt, if necessary.rn                                                                                                          4. Add the pakchoi and crack an egg straight into the simmering soup, letting them poach gently with the noodles. Cook until the pakchoi is tender and the egg whites turn opaque, scooping the hot broth over the egg to speed up the process if you like.rn                                                                                                          5. Carefully scoop the noodles and pakchoi into a bowl before pouring the soup and poached egg over them.rn                                                                                                          6. Finish with a drizzle of chill oil and a sprinkle of spring onions and crispy shallots/toasted sesame seeds if desired. Enjoy.','2020-05-14 13:37:06','Crofty'),(4,'Maki sushi rolls','100g sushi ricern1 sheet nori seaweedrn2 tbsp sushi vinegarrnsoy saucernwasabirnsushi gingerrnroasted white sesame seeds (optional)rnrnpossible fillingsrntuna – sashimi grade, rawrnsalmon – sashimi grade, rawrnavocadorncucumberrncrab sticksrncanned tuna mixed with mayornprawns','1. To make sushi rice, Japanese white rice is mixed with a special sushi rice vinegar.rnrn2. Once you have your sushi rice prepared, you will need to begin by laying out a preparation area with your makisu rolling mat.rnrn3. Place a sheet or nori on the mat and cover two thirds of one side of your nori seaweed with your sushi rice approximately 1cm high.rnrn4. Add your ingredients in a line on top of the rice in the centre. You can choose any combination of ingredients that compliment each other well. We went for salmon, salad and mayonnaise for this one.rnrn5. Now for the fun bit. Using the wooden rolling mat, start rolling up the ingredients away from you, while keeping the roll tight. The moisture from the rice will help it stick together.rnrn6. You can then cut your roll into 6-8 pieces and serve with some soy sauce, wasabi, sushi ginger and cup of sencha green tea.rnrnTips and Informationrn- Try wrapping your sushi rolling mat with cling film before you start rolling as this will not only make the mat easier to clean after using, but helps the sticky rice from getting stuck on the mat.rn- It is a good idea to have a bowl of water next to you when you are making makizushi as it is important to keep your fingers wet so that the rice doesn’t stick to them. It is also a good idea to keep the knife wet when you cut it to guarantee that you get a clean cut.rn- You can make what’s called an Uramaki roll, or an inside out roll. This is made with the nori on the inside and the rice on the outside of the roll. Uramaki is great sprinkled with roasted white sesame seeds.rn- Makizushi usually come in two types, futomaki and hosomaki. Futomaki is a thick roll like the one we are making in the photos above with a selection of ingredients inside. Hosomaki is a thinner version, usually containing just one ingredient such as tuna, salmon or cucumber.rn- You can use any types of ingredients for sushi rolls. Many of the popular ones like California Roll (Crab Sticks, Avocado & Cucumber) and the Philadelphia Roll (Smoked Salmon, Cream Cheese & Cucumber) were both invented outside Japan.','2020-05-14 13:42:52','Crofty'),(5,'Yakitori grilled skewers','chicken breast or thighrnspring onionsrnrnsuggested additional items:rnleekrngreen pepperrnpork belly slicesrnasparagusrnfirm tofu, cubedrnrnsauce:rn1 tbsp cooking sakern1 tbsp mirinrn3 tbsp soy saucern2 tbsp sugarrn1-2 tsp katakuriko potato starch, mixed with cold waterrnrnshichimi pepper seasoning (optional)','1. Let’s begin by making the sauce. Add the cooking sake, mirin and soy sauce to a pan with two tablespoons of sugar. The ratio of these ingredients can be changed to suit your taste as all Japanese yakitori chefs have their own personalised sauce recipes.rnrn2. Add a little katakuriko potato starch dissolved in water to the pan and heat the mix without boiling it before simmering gently. The katakuriko starch is useful for thickening the sauce, but this can be omitted depending on how you prefer your sauce. Allow the sauce to simmer on the stove until the volume has been reduced and it becomes thick and sticky.rnrn3. Take your sauce off the hob and leave aside while we prepare our skewers. Soak the wooden skewers in water beforehand for a few minutes to keep them from burning when we grill our yakitori.rnrn4. Make sure that you cut up your chicken into small bitesize pieces and slice your spring onion into approximately 3cm lengths. Start spearing the ingredients onto your skewers alternately so have a good mix of both chicken and spring onion. Now using a cooking brush, begin glazing the skewer ingredients with your yakitori sauce.rnrn5. The traditional method for the next step is using an open flame grill with special aromatic charcoal sourced from Wakayama prefecture in Japan called Binchotan. Of course, this may prove to be slightly hard to source, so a normal barbecue should work nicely. Start placing the skewers on the barbecue in an area with a strong, even heat.rnrn6. Keep turning the yakitori regularly so they cook evenly and brush more yakitori sauce onto the chicken each time you turn them.rnrn7. Once the chicken has cooked to a golden colour they should be ready to serve, so place them on a plate in pairs and serve with a fresh coating of yakitori sauce. You can also use a little shichimi pepper powder here for some extra spicy flavour.rnrnTips and Informationrn- Although yakitori is traditionally made with pieces of chicken and spring onions, there are many other varieties that you can try. Other options include pieces of pork, asparagus wrapped in pork belly slices, chicken skin, chicken wings and various other vegetables to mix up with the meat. If you are feeling really adventurous, see if your local butcher has chicken hearts as these are delicious as yakitori.rn- If you prefer, you can purchase pre-make yakitori sauce to make things a little easier. However, it’s always fun to make the sauce too and it also enables you to make the sauce to your own personal taste preferences.rn- You can make vegetarian yakitori by using tofu and vegetables as a replacement for the chicken. Simply follow the recipe as normal, but use firm tofu instead. Just make sure that you do not use soft or silken tofu as it will most likely fall apart when you try to grill it.','2020-05-14 13:44:09','Crofty');





DROP TABLE IF EXISTS [recipes_has_cuisine];

CREATE TABLE recipes_has_cuisine (
  [id_recipe] int NOT NULL,
  [cuisine_name] varchar(45) NOT NULL,
  PRIMARY KEY ([id_recipe],[cuisine_name])
 ,
  CONSTRAINT [fk_cuisine_name] FOREIGN KEY ([cuisine_name]) REFERENCES cuisine ([name]) ON UPDATE CASCADE,
  CONSTRAINT [fk_id_recipe_recipes] FOREIGN KEY ([id_recipe]) REFERENCES recipes ([id_recipe]) ON UPDATE CASCADE
) ;

CREATE INDEX [fk_cuisine_name_idx] ON recipes_has_cuisine ([cuisine_name]);






INSERT INTO recipes_has_cuisine VALUES (1,'Japanese'),(2,'Japanese'),(3,'Japanese'),(4,'Japanese'),(5,'Japanese');





DROP TABLE IF EXISTS [recipes_has_ratings];

CREATE TABLE recipes_has_ratings (
  [id_recipe] int NOT NULL,
  [ratings] int NOT NULL,
  [critic] varchar(45) NOT NULL,
  PRIMARY KEY ([id_recipe],[critic])
 ,
  CONSTRAINT [fk_critic_users] FOREIGN KEY ([critic]) REFERENCES users ([username]) ON UPDATE CASCADE,
  CONSTRAINT [fk_id_recipe_ratings_recipes] FOREIGN KEY ([id_recipe]) REFERENCES recipes ([id_recipe]) ON UPDATE CASCADE
) ;

CREATE INDEX [fk_critic_users_idx] ON recipes_has_ratings ([critic]);


DROP TABLE IF EXISTS [comments];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE comments (
  [id_comment] int NOT NULL IDENTITY,
  [content] varchar(500) NOT NULL,
  [date] datetime2(0) NOT NULL,
  [author] varchar(50) NOT NULL,
  PRIMARY KEY ([id_comment])
 ,
  CONSTRAINT [foreignkeyuser] FOREIGN KEY ([author]) REFERENCES users ([username]) ON UPDATE CASCADE
) ;

CREATE INDEX [foreignkeyuser_idx] ON comments ([author]);
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--



--
-- Table structure for table `comments_has_recipes`
--

DROP TABLE IF EXISTS [comments_has_recipes];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE comments_has_recipes (
  [id_comment] int NOT NULL,
  [id_recipe] int NOT NULL,
  PRIMARY KEY ([id_comment],[id_recipe])
 ,
  CONSTRAINT [fk_comment_comments] FOREIGN KEY ([id_comment]) REFERENCES comments ([id_comment]) ON UPDATE CASCADE,
  CONSTRAINT [fk_recipe_recipes] FOREIGN KEY ([id_recipe]) REFERENCES recipes ([id_recipe])  ON UPDATE CASCADE
) ;

CREATE INDEX [fk_recipe_recipes_idx] ON comments_has_recipes ([id_recipe]);








