import React, { useContext } from "react";

import { Context } from "./../context/CalculationContext";

function Result() {
  const { result } = useContext(Context);

  return (
    <>
      <h4>Resultado</h4>
      <label>R$ {result}</label>
    </>
  );
}

export default Result;
