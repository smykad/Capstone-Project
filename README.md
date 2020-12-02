# Capstone Project - CIT 110

This project is for CIT 110, it calculates the square footage of a house with any number of rooms.

## Built With
- C#
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) 

## Getting Started

### Installation

```
https://github.com/smykad/Capstone-Project
```

## Usage

Using these three methods you can enter any number of strings and console colors to change the string to
Had a big help from Wyatt and Noah getting this to work properly

```
	public static void PrintPicture(params object[] arguments)
        {
            List<ConsoleColor> colors = new List<ConsoleColor>();
            List<string> images = new List<string>();
            foreach (object argument in arguments)
            {
                if (argument.GetType() == typeof(string))
                {
                    images.Add(argument.ToString());
                }
                else if (argument.GetType() == typeof(ConsoleColor))
                {
                    colors.Add((ConsoleColor)Enum.Parse(typeof(ConsoleColor), argument.ToString()));
                }
            }

            getImages(colors.ToArray(), images.ToArray());
        }

        static void getImages(ConsoleColor[] colors,
                                     string[] images)
        {
            int i = 0;
            foreach (string image in images)
            {
                SetColor(colors[i]);
                Console.Write(image);
                i++;
                if (i == images.Length)
                {
                    Console.WriteLine();
                }
            }
        }
	
        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
```

I also had a validation class that I find to be fairly useful in there as well so I suggest taking a look at it.

## Contributors

Big shoutout to these guys to helping me out on this project
- [Noah Osterhout](https://github.com/NoahFlowa)
- [Wyatt J. Miller](https://github.com/wymillerlinux)

## Contact

- [Doug Smyka](https://github.com/smykad)
