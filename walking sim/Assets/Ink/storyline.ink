

===STARTINGDIALOGUE===
VIVI: Can't believe we got into this place.
VIVI: Or... I can. My dad's the realtor, after all!
ALEX: Dude, isn't this breaking and entering?
VIVI: Don't be such a buzzkill! Breaking and entering is part of the fun! Naren, what do you think?
+NAREN: Oh hell yeah! It wouldn't be worth it without a little crime.
    -> viviDialogue
+NAREN: Dude, I think Alex is onto something. Maybe we should tread with caution.
    ->alexDialogue

===viviDialogue===
VIVI: That's the spirit! Come on, let's investigate.
->DONE

===alexDialogue===
VIVI: You're such a buzzkill, Naren. Let's see what this place has in store for us.
->DONE

===kitchen_drawer===
A standard kitchen drawer. Where are the scissors?
ALEX: hey dude, not to be a buzzkill, but I gotta take a massive shit right now.
NAREN: Are you kidding me? You should've gone before we left!
NAREN: Whatever. I'll go check the plumbing. If this place is still available to rent, it should work.
->DONE

===kitchen_scissors===
An old pair of kitchen scissors, surprisingly devoid of wear and tear.
NAREN: Found you, you little bastard.
NAREN: Wait a minute... is that hair?
->DONE

===toilet===
A toilet. The flush works. Nothing more to say about it, really.
NAREN: Damn, they didn't clean it at all.
+Tell Alex about the plumbing
    ->YAYYIGETTOTAKEASHIT
+Meh... what's the harm if he doesn't know?
    ->sayNothing
    
    ===YAYYIGETTOTAKEASHIT===
    NAREN: Yo Alex! Toilet's working!
    ALEX: oh thank god
    -> DONE
    
    ===sayNothing===
    I mean, it's still hooked up to the plumbing. It shouldn't really matter.
    ->DONE






