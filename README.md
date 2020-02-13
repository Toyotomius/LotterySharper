# LotterySharper
### Lottery Parser &amp; Frequency Calculator

I can't stress enough that this was a learning project designed solely to get me into programming after a 20+ year hiatus
and no C# experience. There are many things I would do differently now -- but we've all been there haven't we?

Anyone interested is using this project for any reason is welcome to under the license but it is riddled with odd choices
that I doubt I'll ever go back to fix. It was full of experimentation and started out as a single class with some LINQ and
json parsing. It then grew to 4 classes that didn't adhere to any sensible programming paradigms such as SOLID or DRY.

I refactored everything as I began learning SOLID. Then came interfaces, injection and factory pattern. Then Blazor and
automated injection.

The end result is a three-part program.

#### Console App (LotterySharper)

The console app side of the program takes in any lottery json file that is in the correct format and spits out calculated
and sorted by frequency single, pairs, triplets and bonus numbers for that lottery into separate files.

You can configure the program slightly with config.json.
- Set which files to read and run calculations on. Works with any json that follows the below example.
- Set via boolean whether or not to use the pre-built scraping for three lotteries: US' Powerball, Canada's Lotto Max and 
  Lotto 649 to keep those lottery files up to date automatically.
    
Your lottery files should be in this format:
```
{
  "USPowerball": [
    {
      "Date": "Wednesday, August 28, 2019",
      "Numbers": [ 9, 32, 37, 41, 56 ],
      "Bonus": 14
    },
    {
      "Date": "Saturday, August 24, 2019",
      "Numbers": [ 5, 12, 20, 21, 47 ],
      "Bonus": 1
    },
    {
      "Date": "Wednesday, August 21, 2019",
      "Numbers": [ 12, 21, 22, 29, 32 ],
      "Bonus": 21
    }
    ]
}
```

It uses Quartz.net to manage scraping the websites after each new lottery result is posted. There is currently no way to
customize this outside of modifying the source code. Or what websites it will scrape as they are inextricably tied together.

Sorry.

#### Web API App (LotterySharperAPI)

Very basic web API that allows anyone to GET the json for each of the lotteries and their results. Reads from the files created
by the console app.

Address syntax:
```
address/api/lotteryname/calculated info (if desired)
ex:// localhost/api/lotto649/bonus  --- Returns sorted json by frequency of bonus numbers.
```

Has no built-in capability to pull from custom lotteries that aren't the big three I was calculating (Powerball, Lotto 649 &
Lotto Max). Sorry.

#### Blazor server (LotterySharperBlazorServer)

Simple server that pulls from the API to output the jsons as tables. Single page design.

Uses slightly modified version of BlazorTable by Ivan Josipovic : https://github.com/IvanJosipovic/BlazorTable

See below screenshots.

![LotterySharperBlazorServer](https://raw.githubusercontent.com/Toyotomius/LotterySharper/master/LotterySharperBlazorServer/LotterySharperBlazorServer.png)
![LotterySharperBlazorServer](https://raw.githubusercontent.com/Toyotomius/LotterySharper/master/LotterySharperBlazorServer/LotterySharperBlazorServerTable.png)

The project could use a lot of clean up and visual design / css improvements.
