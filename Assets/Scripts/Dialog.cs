﻿public class Dialog
{
    public static D DialogueEntry()
    {
        D e50 = D.Say("And that’s a lie.");
        D e49 = D.Say("“That’s right, come here! Give it to me! Don’t worry, I’ll stay in the darkness, where I belong. For a while” - the monster says.", e50);
        D e48 = D.Choose("Feed the monster", e49, "Let it starve to death", e50);

        D e47dot5 = D.Say("The locker doesn’t look so reliable.  Maybe I don’t want to feed him?", e48, M.showSlot("Slot5"));
        D s15 = D.Sequence(new[]
        {
            "“Try this”, says Docefago and passes me a fresh bone with the rests flesh on it. - “but don’t get too close”.",
            "From personal supplies, I guess?",
            "“You think you’re funny?” - sniffs Docefago. ",
            "Meanwhile the monster inside of cell seem to be interested in this bone. ",
            "“Give it to me!” - he orders. - “Now!”",
            "I put the treat into the bowl. The bowl is clearly too far away for monster to reach it. But somehow I don’t feel enough courage to push in towards the bars.",
        }, e47dot5);
        
        D e47 = D.Say("Chains and also the bars look completely new, like somebody just have put it here. Who? Hah...", s15, M.showSlot("Slot4"));
        
        D e46 = D.Choose("Look at the chains", e47, null, "Look at the floor", s15, M.showSlot("Slot4"));
        D s14 = D.Sequence(new[]
        {
            "Okay, maybe… maybe he is just hungry, huh?.. Sorry, I must be looked scared. That’s because I am panicking. Honestly, have you seen this monster? And he thinks, he is a God?",
            "I look around in search of anything that might help me to survive."

        }, e46);
        D e45 = D.Say("“AND I KEEP ON LIVING ONLY BECAUSE EVERY NEXT MORNING IS A POSSIBILITY TO BREAK OUT”", s14,
            M.showSlot("Slot3"));
        D s13 = D.Sequence(new[]
        {
            "Okay. This is unpleasant. Can’t say I’m a big fan of giant… what is it? Hyena-lyon?.. Ugh.",
            "And the teeth…",
            "“I see you! Come closer! Or what are you, scared?”",
            "“You tiny piece of coward shit",
            "Nice. Passive-agressive mutant monster. And how did I come to this?",
            "Anyway, I make a step backwards. ",
            "“Were are going?! I recognize you!”",
            "“You are the one who created me! Tell me then, oh, Creator!”",
            "“When you look at me do you see lion?”",
            "“Don’t answer. I know, what you are thinking… You think I’m ugly. You are scared of me. You disguised by me”",
            "“But you know what? I AM A GOD AND I WANT TO BE TREATED LIKE GOD”"
        }, e45);
        D e44 = D.Say("“Who’s there?” - I hear low gnarling.", s13, M.showSlot("Slot2"));
        D s12 = D.Sequence(new[]
        {
            "Ah come on! Chains? Honestly? What is it, house of old dominatrix?",
            "“You do understand, that all of this is creation of YOUR brain?” - quietly says Docefago."
        }, e44);
        D e43 = D.Say("I wonder whom am I going to meet here? Dead babies? Worn out kittens?", s12, M.showSlot("Slot1"));
        D e42 = D.Choose("Extreme right door", e43, M.showStrip("Strip_2"), "Extreme left door", e43, M.showStrip("Strip_2"));
        D s11 = D.Sequence(new[]
        {
            "“And, my oh my, what a beautiful creatures you had settled there!”",
            "What are you talking about",
            "“I’m saying, hon, that each of those creations is CRAVING to meet you”.",
            "Well maybe I don’t want to meet them.",
            "“It’s not like you have a choice, if you want to get up. They won’t let you go anywhere”.",
            "What do they want from me?",
            "“That you shall know from them. But trust me, nothing good for you, that’s for sure. Most of them are unhappy with what you have done to them. So my kind advice, hon, don’t get too close, don’t get too involved and for once, try to listen what I tell you”.",
            "You will go with me?",
            "“Yeah, right... “go” is not appropriate word. We are not “going” anywhere. Remember, you can’t walk?”",
            "“So think of this as of transcendental experience, so to say”.",
            "What does it even mean?",
            "“You’ll see. So, choose the door, hon! Go ahead!”",
            "Well. I don’t see other options, do you? It won’t get any worse, I believe. So l choose…"

        }, e42);
        
        D e41 = D.Say("“R-r-r-right. So, you know, you had opened the doors, which you shouldn’t”", s11, M.showSlot("Slot7"));

        D s10 = D.Sequence(new[]
        {
            "“Well, love, here is the problem”",
            "“Remember all the stories you’ve been telling?”",
            "Was trying to forget, actually"
        },e41);
            
        D e40 = D.Say("“Well, love… sorry, hon, here is the problem”", s10);
        D e39 = D.Say("“Liar-liar, pants on fire. Why would you even try to lie me?”", s10);
            
        
        D e38 = D.Choose("Yes", e39, "No", e40);
        
        D s9 = D.Sequence(new[]
        {
            "Interesting, how do they get that breed? I mean, is it his granny had erred with Anubis?",
            "“You know I can hear all of your thoughts, right?”",
            "All righty. We DO have a situation here…",
            "“Glad you’ve admitted that so fast. Now, about the business. You do know, why this happened to you, right?”"

        }, e38);
        
        D e37 = D.Say("it’s not a poodle, but…", s9, M.showSlot("Slot6"));
        D s8 = D.Sequence(new[]
        {
            "Docefago looks at me with a grin. Seriously, a dog? With a pointy ears? I mean, I’m glad "
        }, e37);

        D e36 = D.Say("“Okay, okay, hon, just don’t get stressed more than you are. For your own good, please”.", s8);
        D e35 = D.Say("“You can call me Docefago. Let’s say, I’m here to help you with your… situation”.", s8);

        
        D e34 = D.Choose("Who are you?", e35, "Don’t you call me “Love”, freaking dog!", e36);
        
        D s7 = D.Sequence(new[]
        {
            "“Hello, love”, - he says.",
            "Why does he call me “Love”? We barely know each other!",
            "So, it’s a big anthropomorphic dog in the fine suit sitting near my bed.",
            "“I see, things turn sour. Right, right…”"
        }, e34);
       
        D e33 = D.Say("For example… Who the hell is sitting near my bed?!", s7, M.showSlot("Slot5"));
        D e32 = D.Say("We have more important things to discuss.", e33);

        D e31 = D.Say("You stupid! I can’t, fershtein? No signal goes to my legs.", e32);
        D e30 = D.Say("No. No response. Even Uma Thurman wouldn’t be able to do anything in my shoes. Haha, got it?", e32);
        
        D e29 = D.Choose("Try to move your big toe", e30, "That’s stupid, just get up", e31);
        
        D s6dot5 = D.Sequence(new[]
        {
            "I cover myself with a blanket. And next thing I know is that I am not going to get up anymore. Ever again.",
            "Why? Well. First of all, for what? Really. And hey, I don’t feel my legs anymore anyway. So even if I for some reason…",
            "Okay, I want get up."
        }, e29);

        D e28dot5 = D.Say("I lie down to the bed…", s6dot5, M.showSlot("Slot4"));
        
        D s6 = D.Sequence(new[]
        {
            "Ah, by the way.",
            "Forgot to add. There is no point in searching the umbrella, because... this rain",
            "is",
            "inside",
            "of",
            "my ",
            "head.",
            "That’s for sure, no lying. ",
            "How do I know? Well I could give you couple of arguments, like there’s no puddles on the floor. But you know, I think, considering the story I have to tell you, we should really build our relationship on trust. ",
            "So.",
            "Trust me. ",
            "Umbrella wouldn’t help.",
            "Which is why I make the only right choice and go back to bed.",
            "I mean, what’s the point?..",
        }, e28dot5);
        
        D e28 = D.Say("I have no idea where the umbrella  might be. After all, I’m not even sure I own one.", s6, M.showSlot("Slot3"));
        
        D s5 = D.Sequence(new[]
        {
            "I have a laundry basket? That’s an the find of the century.",
            "It’s empty. Hardly a surprise."
        }, e28);
        
        D s4 = D.Sequence(new[]
        {
            "Ikea. Open storage system.",
            "I remember how I ordered it. Every time I buy something from Ikea I think of Fight club. 'The things you used to own, now they own you'",
            "I’m not sure I can really relate myself to this stuff.",
            "That’s a nice furniture though. I feel like people who spend hours in search of something NOT THAT MAINSTREAM are more… owned by their stuff, than those who just buy the first nice one on the first referral link in Google.",
            "But well, who am I to judge.",
            "And yeah, umbrella is not here."
        }, e28);
        
        D e20 = D.Choose("Look at the wardrobe.", s4, "Look into the laundry basket.", s5);
        
        D s3 = D.Sequence(new[]
        {
            "Wait… What’s that?",
            "It’s raining? In the middle of December? I mean, sure, the weather got crazy since it’s Global Warming about to destroy our ecosystem, but still, rain in the middle of December in my hallway is kinda… weird.",
            "Oh well.",
            "Anyway. I think, I should look for a umbrella."
        }, e20);

        D e13dot5 = D.Say("Its’ middle of December, I should wear a coat… Probably. Or I’ll get sick.I don’t want it, right? I’m supposed not to want this.", s3, M.startRain());
        D e13 = D.Say("I go to the hallway.", e13dot5, M.showSlot("Slot2"));
        D e12 = D.Say("I have to go. I put on my dirty smelly jeans. Those could really use a laundry, but who cares? Not me, that’s for sure.", e13);
        D e11 = D.Say("I kill the alarm. Then I understand, it didn’t actually go off.", e12);
        D e10 = D.Say("I try to reach a half-empty glass with muddy water, but just when I about to grab it, my butterfingers knock it over. My blanket and even sheet get wet. Nice start! Whatever.", e12);
        D e9 = D.Choose("I kill the alarm.", e11, "I want to drink water.", e10);
        
        D s2 = D.Sequence(new[]
        {
            "I put my legs down on the cold floor, dusty and crumby. Blanket fall down slowly from my bony shoulders.",
            "After some time of self-reflection I finally find some will to make a strong intended move to get up.",
            "You know, one of those, when you wake up and stare into the abyss of the ceiling. Like you’re waiting for it to stare back."
        }, e9);
        
        D e5 = D.Say("This story began one lightless morning.", s2, M.showSlot("Slot1"));

        D e4dot5 = D.Say("Little piano, would you help me, please?", e5, M.startMusic());
        
        D s1 = D.Sequence(new[]
        {
            "Welcome, ladies and gentlemen! Glad to see you here on my One-man show!",
            "Now, if you would be so kind as to make yourself comfortable…",
            "We can start."
        }, e4dot5);
        return s1;
    }
}
