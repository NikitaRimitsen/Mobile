using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Blank_ttt : ContentPage
    {

        /*Frame pole;
        Label lbl;
        Grid kvadrat;
        Button newgame, vebor;*/



        Grid grid2x1, grid3x3;
        //BoxView b;
        Image b;
        Button uus_mang;
        public bool esimene;
        int tulemus = 0;
        List<string> tulemused_1 = new List<string> ();
        List<string> tulemused_2 = new List<string>();
        int[,] Tulemused = new int[3, 3];
        public Blank_ttt()
        {
            grid2x1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            grid2x1.Children.Add(uus_mang, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = grid2x1;
            /*newgame = new Button
            {
                Text = "Uus mäng",
                BackgroundColor = Color.SandyBrown,
                TextColor = Color.Black
            };
            vebor = new Button
            {
                Text = "Kes on esimene?",
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.SandyBrown,
                TextColor = Color.Black
            };
            kvadrat = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                },
            };
            //1 - строчка
            kvadrat.Children.Add(new Image { Source = "krest.png" }, 0, 0);//(0-x,0-y)
            kvadrat.Children.Add(new Image { Source = "nolik.png" }, 1, 0);
            kvadrat.Children.Add(new Image { Source = "krest.png" }, 2, 0);
            //2 - строчка
            kvadrat.Children.Add(new BoxView { Color = Color.Red }, 0, 1);
            kvadrat.Children.Add(new BoxView { Color = Color.YellowGreen }, 1, 1);
            kvadrat.Children.Add(new BoxView { Color = Color.Orange }, 2, 1);
            //3 - строчка
            kvadrat.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            kvadrat.Children.Add(new BoxView { Color = Color.Pink }, 1, 2);
            kvadrat.Children.Add(new BoxView { Color = Color.White }, 2, 2);

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            kvadrat.GestureRecognizers.Add(tap);
            pole = new Frame
            {
                Content = kvadrat,
                BorderColor = Color.Black,
                BackgroundColor =  Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            FlexLayout knopka = new FlexLayout
            {
                Children = { newgame, vebor },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            StackLayout st = new StackLayout
            {
                Children = {pole, knopka}
            };
            Content = st;
            st.BackgroundColor = Color.PeachPuff;*/
        }

        

        public async void Kes_on_Esimene()
        {
            string esimine = await DisplayPromptAsync("Kes on esimene?", "Tee valiku Kollane - 1 või Punane - 2", initialValue:"1", maxLength:1, keyboard:Keyboard.Numeric);
            if (esimine == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }

        private void Uus_mang_Clicked(object sender, EventArgs e)
        {          
            Uus_mang();
        }

        public async void Uus_mang()
        {
            bool uus =await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_Esimene();
                int[,] Tulemused = new int[3, 3];
                int tulemus = 0;
                grid3x3 = new Grid
                {
                    BackgroundColor = Color.Black,
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        b = new Image { Source = "belej.jpg" };
                        grid3x3.Children.Add(b, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        b.GestureRecognizers.Add(tap);

                    }
                }
                grid2x1.Children.Add(grid3x3, 0, 0);
            }
            
        }

        //List<string> voit = new List<string> { "001020", "011121", "021222", "000102", "101112", "202122", "001122", "021120" };

        
        public int Kontroll()
        {
            if (Tulemused[0,0]==1 && Tulemused[1,0]==1 && Tulemused[2,0]==1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && 
                Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }

            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[1, 2] == 2|| Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus==1)
            {
                DisplayAlert("Võit", "Esimine on võitja!", "Ok");
                //Uus_mang();

            }
            else if (tulemus==2)
            {
                DisplayAlert("Võit", "Teine on võitja!", "Ok");
                //Uus_mang();
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene==true)
            {
                b = new Image { Source = "krest.png" };
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                b = new Image { Source = "nolik.png" };
                esimene = true;
                Tulemused[r, c] = 2;
            }           
            grid3x3.Children.Add(b, c, r);
            Lopp();
        }
    }
}