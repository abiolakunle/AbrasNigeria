import React from "react";

import Routes from "./Components/Routes/Routes";

import { history } from "./Helpers/history";

import { BrowserRouter as Router } from "react-router-dom";

import { DocumentProvider } from "./Contexts/DocumentContext";

import { CloudinaryContext } from "cloudinary-react";

const App = () => {
  return (
    <CloudinaryContext cloudName="abiolasoft">
      <DocumentProvider>
        <Router history={history} forceRefresh={true}>
          <Routes />
        </Router>
      </DocumentProvider>
    </CloudinaryContext>
  );
};

export default App;
