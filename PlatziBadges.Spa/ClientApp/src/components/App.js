import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import BadgeNew from "../pages/BadgeNew";
import Badges from "../pages/Badges";
import Home from "../pages/Home";
import Layout from "./Layout";
import NotFound from "./NotFound";
import BadgeEdit from "../pages/BadgeEdit";
import BadgeDetailsContainer from "../pages/BadgeDetailsContainer";

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route exact path="/badges" component={Badges} />
          <Route exact path="/badges/new" component={BadgeNew} />
          <Route
            exact
            path="/badges/:badgeId"
            component={BadgeDetailsContainer}
          />
          <Route exact path="/badges/:badgeId/edit" component={BadgeEdit} />
          <Route exact path="/NotFound" component={NotFound} />
          <Route component={NotFound} />
        </Switch>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
