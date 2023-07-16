import React, { useState, useEffect } from 'react';
import { onAuthStateChanged } from "firebase/auth";
import { auth } from '../../firebase';
import { signOut } from "firebase/auth";

 
export default function Home({navigation}){
 
    const handleLogout = () => {               
        signOut(auth).then(() => {
        // Sign-out successful.
            navigation.navigate("Login");
            console.log("Signed out successfully")
        }).catch((error) => {
        // An error happened.
        });
    }
 
  return (
    <>
    <nav>
        <p>
            Welcome Home
        </p>

        <div>
            <button onClick={handleLogout}>
                Logout
            </button>
        </div>
    </nav>
</>
  )
}
 
