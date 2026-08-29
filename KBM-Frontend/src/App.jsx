import { useState } from 'react'
import heroImg from './assets/hero.png'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import { BrowserRouter, Routes, Route } from "react-router-dom";

import Navbar from "./components/Navbar";
import LessonsPage from "./pages/LessonsPage";
import LessonDetailsPage from "./pages/LessonDetailsPage";
import CreateLessonPage from "./pages/CreateLessonPage";
import ChatbotPage from "./pages/ChatbotPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LessonsPage />} />

        <Route
          path="/lessons"
          element={<LessonsPage />}
        />

        <Route
          path="/lessons/:id"
          element={<LessonDetailsPage />}
        />

        <Route
          path="/create-lesson"
          element={<CreateLessonPage />}
        />

        <Route
          path="/chatbot"
          element={<ChatbotPage />}
        />
      </Routes>
    </BrowserRouter>
  );
}

export default App;