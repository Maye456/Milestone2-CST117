using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone2
{
    public partial class SongInventoryForm : Form
    {
        private List<Song> songList = new List<Song>();
        public SongInventoryForm()
        {
            InitializeComponent();
        }

        private void getSongData(Song song)
        {
            decimal price;

            song.SongTitle = tb_songTitle.Text;
            song.Artist = tb_artist.Text;
            song.Album = tb_album.Text;
            song.ReleaseDate = tb_releaseDate.Text;

            if (decimal.TryParse(tb_price.Text, out price))
            {
                song.Price = price;
            }
            else
            {
                MessageBox.Show("Invalid Price");
            }
        }

        private void btn_addSong_Click(object sender, EventArgs e)
        {
            Song mysong = new Song();
            getSongData(mysong);
            songList.Add(mysong);
            songListBox.Items.Add("Album: " + mysong.Album + " - " + mysong.SongTitle + ", " + mysong.Artist +
                    ", " + mysong.ReleaseDate);

            tb_songTitle.Clear();
            tb_artist.Clear();
            tb_releaseDate.Clear();
            tb_album.Clear();

            tb_songTitle.Focus();
        }

        private void songListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = songListBox.SelectedIndex;

            MessageBox.Show(songList[index].Price.ToString("c"));
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class Song
        {
            private string songTitle;
            private string artist;
            private string album;
            private string releaseDate;
            private decimal price;

            public Song()
            {
                songTitle = "";
                artist = "";
                album = "";
                releaseDate = "";
                price = 0m;
            }

            public string SongTitle
            {
                get { return songTitle; }
                set { songTitle = value; }
            }

            public string Artist
            {
                get { return artist; }
                set { artist = value; }
            }

            public string Album
            {
                get { return album; }
                set { album = value; }
            }

            public string ReleaseDate
            {
                get { return releaseDate; }
                set { releaseDate = value; }
            }

            public decimal Price
            {
                get { return price; }
                set { price = value; }
            }
        }
    }
}
