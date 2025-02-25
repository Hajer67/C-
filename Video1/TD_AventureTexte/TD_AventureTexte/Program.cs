using System;

namespace TD_AventureTexte
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowTitle();
            ShowRules();
            Console.WriteLine("Appuyez sur 'entrée' pour continuer");
            Console.WriteLine();
            Console.ReadLine();
            FirstChapter();
            Console.WriteLine("Bravo ! Tu as terminé le chapitre 1. Tu peux désormais commancer le chapitre 2");
            Console.WriteLine("Appuyez sur 'entrée' pour continuer");
            Console.WriteLine();
            Console.ReadLine();
            SndChapter();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("FIN");
            Console.ReadLine();
        }


        static void ShowTitle()
        {
            Console.WriteLine(@" _____       _       _                  _                   ");
            Console.WriteLine(@"/__   \__  _| |_    /_\__   _____ _ __ | |_ _   _ _ __ ___  ");
            Console.WriteLine(@"  / /\/\ \/ / __|  //_\\ \ / / _ \ '_ \| __| | | | '__/ _ \ ");
            Console.WriteLine(@" / /    >  <| |_  /  _  \ V /  __/ | | | |_| |_| | | |  __/ ");
            Console.WriteLine(@" \/    /_/\_\\__| \_/ \_/\_/ \___|_| |_|\__|\__,_|_|  \___| ");
            Console.WriteLine(@"                                                            ");

        }

        static void ShowRules()
        {
            Console.WriteLine();
            Console.WriteLine("But du jeu : Le but du jeu est de libérer la princesse, qui est prisonnière d'un château mystérieux. Le joueur progresse en choisissant entre deux options à chaque étape. La partie est gagnée lorsque la princesse est retrouvée et sauvée.");
            Console.WriteLine();
            Console.WriteLine("Déroulement du jeu :");
            Console.WriteLine("1. Le départ : Le joueur commence son aventure à l'entrée d'un vaste royaume, peuplé de créatures étranges et de chemins mystérieux.");
            Console.WriteLine("2. Choisir son chemin : À chaque étape, le joueur se voit proposer deux choix différents. Chaque choix le mène sur un chemin différent, avec de nouvelles découvertes et défis à surmonter.");
            Console.WriteLine();
            Console.WriteLine("Exemple :");
            Console.WriteLine("'Vous arrivez à un carrefour.À gauche, un sentier sombre mène à une forêt dense.À droite, un pont en bois qui traverse une rivière calme.Où voulez - vous aller ?'");
            Console.WriteLine("   - Choisir la forêt dense");
            Console.WriteLine("   - Traverser le pont");
            Console.WriteLine();
            Console.WriteLine("3. Objectif final : Le joueur remporte la partie lorsqu'il trouve la princesse et parvient à la libérer de son chateau.");
            Console.WriteLine();
            Console.WriteLine("Fin du jeu :");
            Console.WriteLine("- Victoire : Lorsque la princesse est retrouvée et sauvée, le jeu se termine avec une célébration.");
            Console.WriteLine("- Défaite : Lorsque le joueur fait un mauvais choix, le jeu se termine par l'échec de sa mission.");
            Console.WriteLine();


        }

        static void FirstChapter()
        {
            Console.WriteLine("Chapitre 1 : La préparation");
            Console.WriteLine();
            Console.WriteLine("Tu t'avances dans la petite ville qui borde le royaume. La quête pour sauver la princesse s'annonce périlleuse, et avant de partir, il te faut de l'équipement.");
            Console.WriteLine("Deux lieux se dressent devant toi, chacun offrant une forme de préparation différente.");
            Console.WriteLine();
            Console.WriteLine("D'un côté, tu aperçois l'armurerie, un bâtiment imposant où des armes brillent sous le soleil et des armures étincelantes sont suspendues.");
            Console.WriteLine("L'armurier semble occupé à aiguiser des épées et à réparer des boucliers. Il est probable qu'il puisse t'offrir des armes et des protections solides.");
            Console.WriteLine("De l'autre côté, tu vois la boutique de l'enchanteur, une petite échoppe au abords de la ville, remplie de potions, d'objets mystiques et d'artefacts magiques.");
            Console.WriteLine("L'enchanteur, un vieil homme dont la renommée s'étends sur plusieurs royaumes, pourrait t'offrir des objets magiques capables de t'aider à surmonter les obstacles invisibles.");
            Console.WriteLine();
            Console.WriteLine("Que décides-tu de faire ?");
            Console.WriteLine();
            Console.WriteLine("   - Aller à l'armurerie");
            Console.WriteLine("   - Aller chez l'enchanteur");
            Console.WriteLine();
            Console.WriteLine("Ce premier choix définit le début de ton aventure et façonne la manière dont tu aborderas la quête.");
            Console.WriteLine("Quel chemin prendra ton héros ?");
            Console.WriteLine();

            string direction = Console.ReadLine();

            while (direction != "enchanteur" || direction != "armurerie")
            {
                if (direction == "enchanteur")
                {
                    Enchanteur();
                }
                else if (direction == "armurerie")
                {
                    Armurerie();
                }
                else
                {
                    Console.WriteLine("Tu n'as jamais appris à lire ? Tu as le choix entre 'enchanteur' ou 'armurerie' c'est pas compliqué pourtant...");
                    Console.ReadLine();
                }
            }


        }

        static void Enchanteur()
        {
            Console.WriteLine();
            Console.WriteLine("Tu t'approches de la boutique de l'enchanteur, l'air un peu hésitant.");
            Console.WriteLine("L'échoppe semble en ruine, avec des livres de sortilèges empilés en désordre et des fioles qui débordent sur le sol.");
            Console.WriteLine();
            Console.WriteLine("Après avoir fait tinter à deux reprises la sonnette du contoire pour signaler ta présence, tu entends des bruits de pas pressés derrière toi.");
            Console.WriteLine("'Attendez ! J'arrive !' s'écrit une voix de tamia. 'Je suis là !'");
            Console.WriteLine("Cependant tu ne vois personne dans la direction des chicotements. Les bruits de pas s'approchent encore et tu entends de nouveau cette voix insupportable.");
            Console.WriteLine();
            Console.WriteLine("'Je suis juste devant toi. Désolé je me suis rendu invisible en buvant une potion qui était sensée soigner ma toux' Rigole-t-il. 'Personne ne m'a rendu visite depuis une décennie ! J'avais presque oublié comment parler...' s'emu-t-il.");
            Console.WriteLine("C'est avec la morve au nez qu'il renprend 'Tu veux de la magie, hein ? T'as bien fait de venir chez moi, c’est sûr, tu ne trouveras pas mieux, haha... Enfin, peut-être qu'il y en a mieux, mais bon, pas question de me vanter non plus, hein…'");
            Console.WriteLine("Il commence à fouiller dans ses étagères, renversant au passage une pile de livres qui tombe avec un bruit sourd.");
            Console.WriteLine("Après quelques minutes de recherches frénétiques, il te tend un objet mystérieux, recouvert de poussière.");
            Console.WriteLine();
            Console.WriteLine("'Voilà, ça c’est un artefact de protection magique qui appartenait à un des héros de jadis...Je sais plus lequel par contre haha...'");
            Console.WriteLine("En voyant ta mine inquiète il ajoute :'t’inquiète, ça marche à tous les coups, normalement… mais… bon… parfois, tu sais, le héro quand il ne dors pas assez...'");
            Console.WriteLine();
            Console.WriteLine("Ne pouvant supporter sa voix de chipmunk plus longtemps, deux options s'offrent à toi :");
            Console.WriteLine();
            Console.WriteLine("   - Accepter l'artefact");
            Console.WriteLine("   - Refuser l'artefact et chercher ailleurs");
            Console.WriteLine();

            String direction = Console.ReadLine();
            Console.WriteLine();

            while (direction != "accepter" || direction != "refuser")
            {
                if (direction == "accepter")
                {
                    Console.WriteLine("PERDU");
                    Console.WriteLine();
                    Console.WriteLine("Mais il te manques un boulon mon cornichon ! Tu dois être de ceux qui respirent de la compote...");
                    Console.WriteLine("Ton nom restera aux oubliettes et personne ne saura jamais que cet artefact transorme les arriétés qui le portent en champignons.");
                    Environment.Exit(0);
                }
                else if (direction == "refuser")
                {
                    Console.WriteLine("PERDU");
                    Console.WriteLine();
                    Console.WriteLine("L'enchanteur n'ayant pas apprécié ton refus se met à crier de toutes ses forces te faisant tomber dans un coma dont la durée sera racontée dans une légende des décennies plus tard.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Tu n'as jamais appris à lire ? Tu as le choix entre 'accepter' ou 'refuser' c'est pas compliqué pourtant...");
                    Console.ReadLine();
                }
            }

        }

        static void Armurerie()
        {
            Console.WriteLine();
            Console.WriteLine("Tu pousses la porte grinçante de l'armurerie.");
            Console.WriteLine("À l'intérieur, un vieil homme, aussi aimable qu'une porte de cachot, est en train d’essayer de remettre en place une épée qui ne rentre plus dans son râtelier.");
            Console.WriteLine();
            Console.WriteLine("Il tourne immédiatement sa tête dans ta direction, il écarquille les yeux en disant : Ah bah bravo. On rentre, on regarde, on touche à tout, et après ça vient se plaindre que les prix sont trop chers !");
            Console.WriteLine("Sans même te laisser le temps de répondre, il continue : Ah bah tiens, c’est bien le genre des clients ça. 'Moi j’ai rien fait', 'Moi je veux juste une épée', et après ça finit en procès pour coups et blessures !");
            Console.WriteLine("Il te toise de haut en bas avec une moue dubitative 'A la vue de vos paluches toutes molles et de votre posture de spaghetti trop cuite, je peux vous proposer une épée, une hache ou une pancarte où c'est marqué 'Je suis une cible facile'.'");
            Console.WriteLine();
            Console.WriteLine("'Vous preférez quoi ?'");
            Console.WriteLine();
            Console.WriteLine("   - Arc de l'éclair foudroyant");
            Console.WriteLine("   - Masse d'armes 'Casse-Dent'");
            Console.WriteLine();
            Console.WriteLine("'Ouais pas d'épée pour vous finalement, on ne fait pas dans les miniatures ici.'");
            Console.WriteLine();

            String direction = Console.ReadLine();
            Console.WriteLine();

            while (direction != "arc" || direction != "masse")
            {
                if (direction == "arc")
                {
                    Console.WriteLine("PERDU");
                    Console.WriteLine();
                    Console.WriteLine("Le forgeron te regarde avec sa moue dubitative 'Vous n'êtes pas sérieux j'espère vous m'avez l'air plus qu'à moitié borgne...'");
                    Console.WriteLine("Il te chasse de son armurerie après t'avoir donné un cure-dent rouillé pour le déplacement.");
                    Environment.Exit(0);
                }
                else if (direction == "masse")
                {
                    Console.WriteLine("Il te tend l'arme en te disant : 'Si vous ratez, ça fait au moins un courant d'air. Vos ennemis vous remercieront j'en suis sûr...");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Tu n'as jamais été à l'école ? Tu as le choix entre 'arc' ou 'masse' c'est pas compliqué pourtant...");
                    Console.ReadLine();
                }
            }
        }

        static void SndChapter()
        {
            Console.WriteLine("Chapitre 2 : L'affrontement");
            Console.WriteLine();
            Console.WriteLine("Après avoir rassemblé ce qu'il reste de ton courage et après t'être équipé avec les moyens dont tu disposes, tu poursuis ta route dans la fôret.");
            Console.WriteLine("Il fait sombre, ça bruisse de partout, et tu es à peu près sûr d’avoir entendu une créature mystérieuse et surement très dangereuse dire 'Miam'.");
            Console.WriteLine();
            Console.WriteLine("Ton instinct de survie étant proche de celui d’un pigeon en période de chasse, tu cherches une solution pour éviter de paniquer totalement. Deux options s’offrent à toi :");
            Console.WriteLine();
            Console.WriteLine("   - Manger un champignon aux effets aléatoires");
            Console.WriteLine("   - Faire face à une horde de gobelins");
            Console.WriteLine();
            Console.WriteLine("Tout ça pour te procurer des victuailles parce que tu as oublié de faire des courses avant de partir...");

            String direction = Console.ReadLine();
            Console.WriteLine();

            while (direction != "champignon" || direction != "gobelin")
            {
                if (direction == "champignon")
                {
                    Console.WriteLine("PERDU");
                    Console.WriteLine();
                    Console.WriteLine("On ne t'as jamais appris à ne jamais faire confiance aux champignons violet avec des petits points rouges qui clignotent ?");
                    Console.WriteLine("Et bien c'est dommage parce tu te retrouves avec l'apparence d'un concombre qui pourrait bien terminer dans une des potions de l'enchanteur...");
                    Environment.Exit(0);
                }
                else if (direction == "gobelin")
                {
                    Console.WriteLine("Vous avancez prudemment… puis vous entendez un bruit. Un bruit qui ne laisse place à aucun doute : 'GRUIIIIIIIIK !'");
                    Console.WriteLine();
                    Console.WriteLine("Une trentaine de gobelins sortent des fourrés, armes à la main, et visiblement en manque d’exercice physique.");
                    Console.WriteLine();
                    Console.WriteLine("Tu essaies de négocier pacifiquement un peu de nourriture en essayant de les impressionner avec une danse rituelle improvisée.");
                    Console.WriteLine();
                    Console.WriteLine("Loin d'avoir été touché par ce mouvement de hanches des plus ridicules, les gobelins se mettent à ta poursuite.");
                    Console.WriteLine("Tu décides de prendre ton courage à deux mains et de te taper ton meilleur sprint avant de décider de vivre dans la forêt tel un tarzan d'un roman de mauvais gout");
                    break;
                }
                else
                {
                    Console.WriteLine("Tu as vraiment le QI d'un haricot... Tu as le choix entre 'champignon' ou 'gobelin' c'est la dernière fois que je te file un coup de pouce.");
                    Console.ReadLine();
                }
            }
        }
       


    }
}
