import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";

function Home() {
  const history = useHistory();

  useEffect(() => {
    history.push("/calculation");
  }, []);

  return <></>;
}

export default Home;
