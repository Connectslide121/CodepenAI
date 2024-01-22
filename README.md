![alt text](https://github.com/Connectslide121/codepen-ai/blob/master/Connect_banner_github.png)

# CodepenAI

Introducing an innovative web development platform, harnessing the power of AI to create a dynamic and intuitive code editor experience. Craft your website effortlessly through seamless conversational interactions with the AI. Whether you choose to articulate your code verbally, fine-tune AI-generated scripts, or let the AI take the lead in code creation... the possibilities are boundless. Elevate your coding experience with limitless options for collaboration and creativity. Welcome to a new era of intuitive web development with our AI-enhanced Codepen-style editor!

Try it [here](https://connectslide121.github.io/codepen-ai/)

Back-end repository [here](https://github.com/Connectslide121/CodepenAI-API)

## Overview

The app is built with React and uses OpenAI's GPT-3.5 API to generate the code based on the user's description. The main features are:

- A textarea for the user to describe the web app they want to build
- A button to generate code by calling the OpenAI API
- Display of generated HTML, CSS, and JS code blocks
- Option to edit the generated code blocks
- Saving generated projects
- Viewing and editing previously saved projects

## Code Structure

- `src/index.js` - Entry point that renders App component
- `src/components/App.js` - Main App component
- `src/components/` - Other React components
- `src/functions/` - Small utility/helper functions
- `src/APIs/` - API calling functions
- `src/style.css` - Global styles

Main components:

- `HomePage` - Home page with project list and create form
- `ProjectPage` - View and edit a single project
- `CodeEditor` - CodeMirror editor component

## APIs Used

- OpenAI (GPT-3) - For generating code from text descriptions
- Unsplash - For providing images based on alt text
