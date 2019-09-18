import React from "react";

import Routes from "./Components/Routes/Routes";

import { history } from "./Helpers/history";

import { BrowserRouter as Router } from "react-router-dom";

import { DocumentProvider } from "./Contexts/DocumentContext";

const App = () => {
  return (
    <DocumentProvider>
      <Router history={history} forceRefresh={true}>
        <Routes />
      </Router>
    </DocumentProvider>
  );
};

export default App;
