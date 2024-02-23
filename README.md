![CodepenAI Banner](https://github.com/Connectslide121/codepen-ai/blob/master/Connect_banner_github.png)

# CodepenAI

Welcome to CodepenAI, where the future of web development meets the power of artificial intelligence. Our platform offers a unique code editor experience that allows you to interact with AI in a conversational manner, making web development more intuitive and accessible than ever before.

Check out the live demo [here](https://connectslide121.github.io/CodepenAI-livedemo/).

## Features

- **AI-Powered Code Generation**: Describe what you want in plain text and let the AI generate the HTML, CSS, and JavaScript code for you.
- **Interactive Code Editor**: Fine-tune the AI-generated code or write your own with our codemirror code editor.
- **Project Management**: Save your projects and come back to them anytime. Edit and update as needed with ease.
- **Live Demo**: Try out the editor with a live demo. Please note that there is no back-end, and data will reset upon page reload.

## Installation

To run CodepenAI locally, follow these steps:

1. Clone the repository:

```sh
git clone https://github.com/Connectslide121/codepenAI.git
```

2. Navigate to the project directory:

```sh
cd codepenAI
```

3. Install dependencies:

```sh
npm install
```

4. Configure database:

Set up the connection string for the database you want to use. Back end is written to use a MySQL server.

5. Start the development server:

This script will start back and front ends concurrently.

```sh
npm run dev
```

### Available Scripts

In the project directory, you can run:

- `npm run dev`: Runs the app in development mode.
- `npm run endpoints`: Runs the server app in development mode.
- `npm start`: Runs the client app in development mode.
- `npm run build`: Builds the app for production to the build folder.
- `npm run predeploy`: Runs the build script and deploys the app to GitHub Pages.
- `npm run deploy`: Deploys the app to GitHub Pages.
- `npm test`: Launches the test runner in interactive watch mode.
- `npm run eject`: Removes the single build dependency from your project.

### Code Structure

- `src/index.js` - Entry point that renders App component
- `src/components/App.js` - Main App component
- `src/components/` - Other React components
- `src/functions/` - Small utility/helper functions
- `src/APIs/` - API calling functions
- `src/style.css` - Global styles

### Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.

1. Fork the Project

2. Create your Feature Branch

```sh
git checkout -b feature/AmazingFeature
```

3. Commit your Changes

```sh
git commit -m 'Add some AmazingFeature'
```

4. Push to the Branch

```sh
git push origin feature/AmazingFeature
```

5. Open a Pull Request

### Acknowledgements

[OpenAI API](https://openai.com/blog/openai-api)

[React-codemirror npm](https://www.npmjs.com/package/@uiw/react-codemirror)

### License

Distributed under the MIT License. See LICENSE for more information.

## Enjoy coding with AI at your fingertips!
