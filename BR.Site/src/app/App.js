import { BrowserRouter } from "react-router-dom";

import Routes from "./../routes/Routes";

import "./App.css";

function App() {
  return (
    <BrowserRouter>
      <Routes></Routes>
    </BrowserRouter>
  );
}

export default App;
