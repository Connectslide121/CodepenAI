import React, { useEffect, useState } from "react";
import ReactGA from "react-ga";
import "../style.css";

import Codepen from "./CustomCodePen.jsx";
import InputArea from "./InputArea.jsx";
import Header from "./Header.jsx";
import CallOpenai from "../APIs/Openai.js";
import LoadingState from "./LoadingState.jsx";
import CallGemini from "../APIs/Gemini.js";

import { addImages } from "../functions/ImageAttatcher.js";
import { CreateProject, GetProjects, UpdateProject } from "../APIs/API.js";

const trackingID = "G-VF2P86QY5Q";
ReactGA.initialize(trackingID);

function App() {
  const [html, setHtml] = useState("");
  const [css, setCss] = useState("");
  const [js, setJs] = useState("");
  const [currentCode, setCurrentCode] = useState("");
  const [loadingMessage, setLoadingMessage] = useState("");

  useEffect(() => {
    ReactGA.pageview(window.location.pathname);
  }, []);

  const handleCodeChangeFromUser = (newCode) => {
    setCurrentCode(newCode);
  };

  function PromptBuilder(userInput) {
    const prompt = `User input:\n\
  ${userInput}.\n\
    \n\
  Current state of the code blocks:\n\
  ${currentCode}`;

    return prompt;
  }

  const handleSubmit = (userMessage, apiKey) => {
    async function requestAPI() {
      setLoadingMessage("Generating code...");
      const codeAI = await CallOpenai(PromptBuilder(userMessage), apiKey);

      const htmlCode = codeAI[0];
      setLoadingMessage("Getting images...");
      const htmlCodeWithImages = await addImages(htmlCode);

      setHtml(htmlCodeWithImages);
      setCss(codeAI[1]);
      setJs(codeAI[2]);
      setLoadingMessage("");
    }
    requestAPI();
  };

  const updateImages = async (htmlToUpdate) => {
    setLoadingMessage("Getting images...");
    const updatedHtml = await addImages(htmlToUpdate);
    setHtml(updatedHtml);
    setLoadingMessage("");
  };

  return (
    <>
      <Header />
      <InputArea onUserSubmit={handleSubmit} />
      <LoadingState message={loadingMessage} />
      <Codepen
        htmlCode={html}
        cssCode={css}
        jsCode={js}
        onCodeChange={handleCodeChangeFromUser}
        updateImages={updateImages}
        saveProject={CreateProject}
        openProjects={GetProjects}
        updateProject={UpdateProject}
      />
    </>
  );
}

export default App;