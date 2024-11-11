import axios from "axios";

// Configure the base URL for all requests
const api = axios.create({
    baseURL: "http://localhost:3000/api"
});

export default api;