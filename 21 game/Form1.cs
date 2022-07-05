using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_game
{
    public partial class Form1 : Form
    {
        int cardcount=-1;
        static List<int> Startcards = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        static List<int> cards = new List<int>(Startcards);
        private int playercount=0;
        private int botcount=0;
        bool playerpass, botpass;
        Random r = new Random();
        Label [] cardds = new Label[5];
        public Form1()
        {
            InitializeComponent();
            cardcount = -1;
            
            cardds[0] = Card1Text;
            cardds[1] = Card2Text;
            cardds[2] = Card3Text;
            cardds[3] = Card4Text;
            cardds[4] = Card5Text;
            Card1Text.Text = "";
            Card2Text.Text = "";
            Card3Text.Text = "";
            Card4Text.Text = "";
            Card5Text.Text = "";
            label1.Text = "";
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Card1Text.Text = "";
            Card2Text.Text = "";
            Card3Text.Text = "";
            Card4Text.Text = "";
            Card5Text.Text = "";
            label1.Text = "";
            label2.Text = "";
            label1.Text = "";
            label2.Text = "";
            playercount = 0;
            botcount = 0;
            cardcount = -1;
            cards.Clear();
            playerpass = false;
            botpass = false;
            for(int i =1; i <= 11; i++)
            {
                cards.Add(i);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (botcount > 16)
                botpass = true;
            playerpass = true;
            if(playerpass == true && botpass == true)
            {
                pass();
            }
            else
            {
                pull("bot");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (playerpass == true && botpass == true)
            {
                pass();
            }
            if (playercount < 21)
            {
                cardcount++;
                pull("player");
            }
            else
            {
                playerpass = true;
            }
            
        }

        private void pull(string who)
        {
            int numbufcard;
            if (botcount > 21)
                botpass = true;
            if (playercount > 21)
                playerpass = true;
            switch (who)
            {
                case "player":
                    numbufcard = r.Next(0, cards.Count - 1);
                    playercount += cards[numbufcard];
                    label1.Text = Convert.ToString(playercount);
                    cardds[cardcount].Text = Convert.ToString(cards[numbufcard]);
                    cards.RemoveAt(numbufcard);
                    pull("bot");
                    if (playercount > 16)
                        playerpass = true;
                    break;
                case "bot":
                    numbufcard = r.Next(0, cards.Count - 1);
                    if (botcount <= 16  && check(cards) == true)
                    {
                        cards.RemoveAt(numbufcard);
                        botcount += cards[numbufcard]-1;
                        label2.Text = Convert.ToString(botcount);  
                    }
                    else
                    {
                        botpass = true;
                        pass();
                    }
                    
                    break;
            }
        }
        private void pass()
        {
            if (botcount > playercount && botcount <= 21)
            {
                MessageBox.Show("Вы проиграли!");
            }
            else if (botcount < playercount && playercount <= 21)
            {
                MessageBox.Show("Вы выиграли!");
            }
            else if (botcount == playercount || playercount >21 && botcount > 21)
            {
                MessageBox.Show("Ничья!");
            }
            else if(botcount>21 && playercount <= 21)
            {
                MessageBox.Show("Вы выиграли!");
            }
            else if(botcount <= 21 && playercount > 21)
            {
                MessageBox.Show("Вы выиграли!");
            }
        }
        private bool check(List<int> l)
        {
            int coltrue = 0;
            int colfalse = 0;
            for(int i =0; i< l.Count; i++)
            {
                if (l[i] > (21 - botcount))
                {
                    colfalse++;
                }
                else
                {
                    coltrue++;
                }
                
            }
            if (colfalse > coltrue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
}
