'use client'
import React, { useState, useEffect } from "react";
import axios from "axios";
import { useRouter } from 'next/router';

function LoginForm() {
    const [Login, setLogin] = useState<string>("");
    const [Password, setPassword] = useState<string>("");
    const [isMounted, setIsMounted] = useState(false);
    

    // Ensure the component is only using the router on the client side
    useEffect(() => {
        setIsMounted(true);
    }, []);

    const handleLogin = async (e: React.FormEvent) => {
        const router = useRouter();
        e.preventDefault();
        try {
            const response = await axios.post("/api/login", {
                Login,
                Password
            });
            console.log(response.data);

            if (response.status === 200) {
                router.replace("/");  // Replace '/dashboard' with the page you want to redirect to
            }
        } catch (error) {
            console.error("Login failed:", error);
        }
    };


    return (
        <div className="grid place-items-center h-screen">
            <div className="shadow-lg p-5 rounded-lg border-t-4 border-purple-400"> 
                <form onSubmit={handleLogin} className="flex flex-col gap-4">
                    <input
                        type="text"
                        value={Login}
                        onChange={(e) => setLogin(e.target.value)}
                        placeholder="Login"
                        required
                    />
                    <input
                        type="Password"
                        value={Password}
                        onChange={(e) => setPassword(e.target.value)}
                        placeholder="Password"
                        required
                    />
                    <button className="bg-purple-500 rounded-lg p-2 text:white" type="submit">Login</button>
                </form>
            </div>
        </div>
    );
};

export default LoginForm;
