Routes

Decriptions for each page plus interactions:

/Experiences/
	Paginated list of posts that have the experiences category. 5-10 items per page.
	Item will have the post title, a screenshot, and possibly a part of the text. Either a single paragraph or a max amount of characters.
	Clicking on the post will take you to the full piece.
/Experiences/<id>/
	A details page of the post with full markup and screenshots.
	Page will have content that's taken from the DB as pure html text. (Is there a better way? Richtext or something)
/Concepts/
/Concepts/<id>/
	Both same as above, but posts shown will be filtered by the concepts category.
	Technically both /<id>/ pages would be the same, meaning duplicate code, solution? 


/Post/Create
	Page to create new experience, only requires Title and Category. Upon creation redirect to the modify page.
/Post/Modify/<id>
	Page where you can edit a post. For content to be added you first have to select the language. If the content already exists it should clearly load.
	Upon there being text in the content area one should confirm swapping a language before losing possible data.
	Could possibly use a plugin that allows for live html page editing, but only for the content area?

/Games/
	Page that will contain a bunch of web games that I've made. Should just include links to subsequent static pages.
/Games/TicTacToe/
	Example for the above.

/About/
	A static page about me, probably. Would include personal information like my colorblindness and personal philosophy about gaming.
	