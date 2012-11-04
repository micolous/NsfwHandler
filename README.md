# NsfwHandler #

Windows URI handler for Not Safe for Work (NSFW) links.

Copyright 2012 Michael Farrell <http://micolous.id.au>.  It is licensed under the GPLv3.

## Usage ##

In order to install the URI handler, run the command as an Administrator:

    nsfwhandler -i

This will then change the URI handlers for `nsfw://` and `nsfws://` links to this program.  You can remove these with:

    nsfwhandler -u

After this, open any URI, replacing `http://` with `nsfw://` or `https://` with `nsfws://`.  This will then display a prompt asking you to confirm that you wish to visit the website, and if confirmed, will open it with your default web browser.

## Building ##

You should be able to build this on Visual Studio 2005 or later against .NET 2.0.
