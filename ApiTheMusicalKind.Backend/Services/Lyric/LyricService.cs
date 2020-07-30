﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public class LyricService : BaseService, ILyricService
    {
        public string Get(string resourceUrl)
        {
            return Item(resourceUrl);
        }

        public int GetCount(string resourceUrl)
        {
            return Count(resourceUrl);
        }

        public CustomLyric GetCustom(string resourceUrl)
        {
            var lyric = Item(resourceUrl);

            return new CustomLyric()
            {
                Lyrics = lyric,
                Common = GetCommon()
            };
        }

        private readonly string lyrics = @"My tea's gone cold I'm wondering why I Got out of bed at all The morning rain clouds up my window And I can't see at all And even if I could it'll all be gray, but your picture on my wall It reminds me that it's not so bad, it's not so bad My tea's gone cold I'm wondering why I Got out of bed at all The morning rain clouds up my window And I can't see at all And even if I could it'll all be gray, but your picture on my wall It reminds me that it's not so bad, it's not so bad Dear Slim, I wrote but you still ain't callin' I left my cell, my pager and my home phone at the bottom I sent two letters back in autumn, you must not'a got 'em There probably was a problem at the post office or somethin' Sometimes I scribble addresses too sloppy when I jot 'em But anyways; fuck it, what's been up? Man, how's your daughter? My girlfriend's pregnant too, I'm 'bout to be a father If I have a daughter, guess what I'mma call her? I'mma name her Bonnie I read about your Uncle Ronnie, too, I'm sorry. I had a friend kill himself over some bitch who didn't want him I know you probably hear this everyday, but I'm your biggest fan I even got the underground shit that you did with Skam I got a room full of your posters and your pictures man I like the shit you did with Rawkus too; that shit was phat! Anyways, I hope you get this man, hit me back, just to chat Truly yours, your biggest fan, this is Stan My tea's gone cold I'm wondering why I Got out of bed at all The morning rain clouds up my window And I can't see at all And even if I could it'll all be gray, but your picture on my wall It reminds me that it's not so bad, it's not so bad Dear Slim, you still ain't called or wrote, I hope you have a chance I ain't mad, I just think it's fucked up you don't answer fans If you didn't wanna talk to me outside your concert You didn't have to, but you coulda signed an autograph for Matthew That's my little brother man, he's only six years old We waited in the blistering cold for you, four hours and you just said, 'No' That's pretty shitty man, you're like his fuckin' idol He wants to be just like you man, he likes you more than I do I ain't that mad though, I just don't like bein' lied to Remember when we met in Denver, you said if I'd write you You would write back, see I'm just like you in a way I never knew my father neither He used to always cheat on my mom and beat her I can relate to what you're saying in your songs So when I have a shitty day, I drift away and put 'em on 'Cause I don't really got shit else so that shit helps when I'm depressed I even got a tattoo of your name across the chest Sometimes I even cut myself to see how much it bleeds It's like adrenaline, the pain is such a sudden rush for me See everything you say is real, and I respect you cause you tell it My girlfriend's jealous 'cause I talk about you twenty-four/seven But she don't know you like I know you Slim, no-one does She don't know what it was like for people like us growin' up You gotta call me man, I'll be the biggest fan you'll ever lose Sincerely yours, Stan P.S. We should be together, too My tea's gone cold I'm wondering why I Got out of bed at all The morning rain clouds up my window And I can't see at all And even if I could it'll all be gray, but your picture on my wall It reminds me that it's not so bad, it's not so bad Dear Mr. I'm-Too-Good-To-Call-Or-Write-My-Fans: This'll be the last package I ever send your ass! It's been six months and still no word, I don't deserve it? I know you got my last two letters; I wrote the addresses on 'em perfect So this is my cassette I'm sending you, I hope you hear it I'm in the car right now, I'm doing 90 on the freeway Hey Slim, I drank a fifth of vodka, you dare me to drive? You know the song by Phil Collins, 'In the Air Tonight'? About that guy who coulda saved that other guy from drowning? But didn't, then Phil saw it all, then at a show he found him? That's kinda how this is, you coulda rescued me from drowning Now it's too late, I'm on a thousand downers now, I'm drowsy And all I wanted was a lousy letter or a call I hope you know I ripped all of your pictures off the wall I love you Slim, we coulda been together, think about it You ruined it now, I hope you can't sleep and you dream about it And when you dream, I hope you can't sleep and you scream about it I hope your conscience eats at you and you can't breathe without me See Slim; shut up bitch! I'm tryin' to talk! Hey Slim, that's my girlfriend screamin' in the trunk But I didn't slit her throat, I just tied her up, see I ain't like you 'Cause if she suffocates, she'll suffer more and then she'll die too Well, gotta go, I'm almost at the bridge now - Oh, shit! I forgot! How am I supposed to send this shit out? My tea's gone cold I'm wondering why I Got out of bed at all The morning rain clouds up my window And I can't see at all And even if I could it'll all be gray, but your picture on my wall It reminds me that it's not so bad, it's not so bad Dear Stan, I meant to write you sooner but I just been busy You said your girlfriend's pregnant now, how far along is she? Look, I'm really flattered you would call your daughter that And here's an autograph for your brother, I wrote it on the Starter cap I'm sorry I didn't see you at the show, I musta missed you Don't think I did that shit intentionally just to diss you But what's this shit you said about you like to cut your wrists too? I say that shit just clownin' dogg; c'mon, how fucked up is you? You got some issues Stan, I think you need some counselling To help your ass from bouncing off the walls when you get down some And what's this shit about us meant to be together? That type of shit'll make me not want us to meet each other! I really think you and your girlfriend need each other Or maybe you just need to treat her better I hope you get to read this letter, I just hope it reaches you in time Before you hurt yourself, I think that you'll be doin' just fine If you relax a little, I'm glad I inspire you, but Stan Why are you so mad? Try to understand, that I do want you as a fan I just don't want you to do some crazy shit I seen this one shit on the news a couple weeks ago that made me sick Some dude was drunk and drove his car over a bridge And had his girlfriend in the trunk and she was pregnant with his kid And in the car they found a tape, but they didn't say who it was to Come to think of it, his name was... it was you! Damn...";

        private IEnumerable<IGrouping<string, string>> GetCommon()
        {
            return Regex.Split(lyrics.ToLower(), @"\W+")
                .Where(s => s.Length > 3)
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(5);
        }

        //private static string Item(string resourceUrl)
        //{
        //    var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

        //    using var httpClient = new HttpClient { BaseAddress = baseAddress };
        //    using var response = httpClient.GetAsync(resourceUrl);

        //    var responseData = response.Result.Content.ReadAsStringAsync();

        //    var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData.Result);

        //    return result.Lyrics;
        //}
    }
}
