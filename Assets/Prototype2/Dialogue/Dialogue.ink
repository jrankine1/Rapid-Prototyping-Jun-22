-> main

=== main ===
Okay...I've been tasked to retrieve data from a rogue AI...
I have to ask questions to find out what the data is and where they got it...

    + [What are you?]
        -> chosen("What are you?")
    + [What data did you steal?]
        -> chosen("What data did you steal?")
    + [Why did you go rogue?]
        -> chosen("Why did you go rogue?")
        
=== chosen(pokemon) ===
TAI: I am an AI created by Gilga labs...
-> END