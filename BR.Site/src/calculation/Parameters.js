import React, { useState, useContext } from "react";

import { Context } from "./../context/CalculationContext";

function Parameters() {
  const { executeCalculation } = useContext(Context);

  const [initialValue, setInitialValue] = useState(1);
  const [months, setMonths] = useState(1);

  const submitEvent = (e) => {
    e.preventDefault();

    executeCalculation(initialValue, months);
  };

  return (
    <>
      <h5>Preencha os valor para a realização do cálculo de júros</h5>
      <form onSubmit={submitEvent} className="form-inline mt-4 mb-2">
        <label className="sr-only" htmlFor="inputValor">
          Valor inicial
        </label>
        <input
          type="text"
          className="form-control mb-2 mr-sm-2"
          id="inputValor"
          value={initialValue}
          onChange={(e) => setInitialValue(e.target.value)}
          placeholder="R$ 500,00"
        />

        <label className="sr-only" htmlFor="inputMeses">
          Meses
        </label>
        <div className="input-group mb-2 mr-sm-2">
          <input
            type="text"
            className="form-control"
            id="inputMeses"
            value={months}
            onChange={(e) => setMonths(e.target.value)}
            placeholder="12"
          />
        </div>

        <button type="submit" className="btn btn-primary mb-2">
          Calcular
        </button>
      </form>
    </>
  );
}

export default Parameters;
