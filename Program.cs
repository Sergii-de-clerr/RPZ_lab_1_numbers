using NAudio.Wave;

namespace Lab_1_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chislo = Convert.ToInt32(Console.ReadLine());
            if (chislo == 0)
                PlayMP3(Convert.ToString(chislo));
            else
                ParseNPlayNum(chislo);
        }

        public static void ParseNPlayNum(int n)
        {
            int faken;
            if (1000 <= n && n < 1000000)
            {
                faken = n / 1000;
                int f = (faken % 100);
                if (faken >= 100)
                    ParseNPlayNum(faken - (faken % 100));
                if (20 <= f && f < 100)
                {
                    int fak = (f - (f % 10));
                    PlayMP3(Convert.ToString(fak));
                    int i = (f % 10);
                    if (i == 1)
                    {
                        PlayMP3("Одна");
                        PlayMP3("Тисяча");
                    }
                    else if (i == 2)
                    {
                        PlayMP3("Дві");
                        PlayMP3("Тисячі");
                    }
                    else
                    {
                        PlayMP3(Convert.ToString(i));
                        PlayMP3("Тисяч");
                    }
                }
                else if (11 <= f && f < 20)
                {
                    PlayMP3(Convert.ToString(f));
                    PlayMP3("Тисяч");
                }
                else if (0 <= f && f < 10)
                {
                    if (f == 1)
                    {
                        PlayMP3("Одна");
                        PlayMP3("Тисяча");
                    }
                    else if (f == 2)
                    {
                        PlayMP3("Дві");
                        PlayMP3("Тисячі");
                    }
                    else
                    {
                        PlayMP3(Convert.ToString(f));
                        PlayMP3("Тисяч");
                    }
                }
                ParseNPlayNum((n % 1000));
            }
            else if (100 <= n && n < 1000)
            {
                faken = (n - (n % 100));
                PlayMP3(Convert.ToString(faken));
                ParseNPlayNum((n % 100));
            }
            else if (20 <= n && n < 100)
            {
                faken = (n - (n % 10));
                PlayMP3(Convert.ToString(faken));
                ParseNPlayNum((n % 10));
            }
            else if (1 <= n && n < 20)
            {
                PlayMP3(Convert.ToString(n));
            }
        }

        public static void PlayMP3(string name)
        {
            AudioFileReader audioFile = new($"F:/4-й курс/RPZ/RPZ_lab_1_numbers/Sounds/mp3/{name}.mp3");
            WaveOutEvent outputDevice = new();

            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
                continue;
        }
    }
}
