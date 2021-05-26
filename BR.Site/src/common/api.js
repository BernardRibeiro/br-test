import axios from "axios";
import https from "https";

const instance = axios.create({
  httpsAgent: new https.Agent({
    rejectUnauthorized: false,
  }),
  baseURL: process.env.REACT_APP_BASEURL,
});

instance.defaults.headers = {
  "Content-Type": "application/json",
  "Cache-Control": "no-cache",
};

export default instance;
