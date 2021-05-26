import React from "react";

import { CalculationContext } from "./../context/CalculationContext";
import Parameters from "./../calculation/Parameters";
import Result from "./../calculation/Result";

function Calculation() {
  return (
    <>
      <h3>Cálculo de Júros</h3>
      <CalculationContext>
        <Parameters />
        <Result />
      </CalculationContext>
    </>
  );
}

export default Calculation;
