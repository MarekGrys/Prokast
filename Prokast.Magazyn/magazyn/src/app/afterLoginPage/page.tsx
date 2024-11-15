import ChoiceMenu from "@/components/choiceMenu";
import React from "react";
export default function AfterLogin() {
  return (
    <div className="w-screen h-screen bg-backGroundColor">
      
        <ChoiceMenu/>
        <div className="flex flex-row w-full h-5/6">
          <div className="flex flex-col p-4 pt-10 gap-6 w-1/6 h-full bg-backGroundColor border-solid border-black border">
            <p className="font-semibold text-3xl">Zestaw Statyczny</p>
            <p className="text-lg font-semibold">Zestaw</p>
            <p className="text-lg font-semibold">Import</p>
            <p className="text-lg font-semibold">Dodatki</p>
            <p className="text-lg font-semibold">Ustawienia</p>
          </div>
          <div className="border-solid w-5/6 h-full  border-black border">
            <div className="flex flex-row justify-between w-full p-4 bg-gray-300 gap-4 space-x-8 items-center">
              <p className="">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <button className="border-4 border-solid border-menuColor p-4 rounded-xl font-semibold">Edytuj</button>
              <button className="border-4 border-solid border-red-600 text-red-600 p-4 rounded-xl font-semibold ">Usuń</button>
            </div>
            <div className="flex flex-row justify-between w-full p-4 gap-4 space-x-8 items-center">
              <p className="">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <button className="border-4 border-solid border-menuColor p-4 rounded-xl font-semibold">Edytuj</button>
              <button className="border-4 border-solid border-red-600 text-red-600 p-4 rounded-xl font-semibold ">Usuń</button>
            </div>
            <div className="flex flex-row justify-between w-full p-4 bg-gray-300 gap-4 space-x-8 items-center">
              <p className="">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <button className="border-4 border-solid border-menuColor p-4 rounded-xl font-semibold">Edytuj</button>
              <button className="border-4 border-solid border-red-600 text-red-600 p-4 rounded-xl font-semibold ">Usuń</button>
            </div>
            <div className="flex flex-row justify-between w-full p-4 gap-4 space-x-8 items-center">
              <p className="">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <p className=" ">Jakieś dane </p>
              <button className="border-4 border-solid border-menuColor p-4 rounded-xl font-semibold">Edytuj</button>
              <button className="border-4 border-solid border-red-600 text-red-600 p-4 rounded-xl font-semibold ">Usuń</button>
            </div>
          </div>
        </div>
    </div>
        
  );
}
