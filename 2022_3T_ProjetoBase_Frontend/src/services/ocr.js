import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    await axios({
        method: "POST",
        url: "https://ocr-equipaments-testeum.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
            "Ocp-Apim-Subscription-Key": "693e07de2ccb428da0cf6d817fb12227"
        }
    })
        .then(response => {
            // console.log(response)
            resultado = FiltrarObjeto(response.data);
        })
        .catch(erro => console.log(erro))

    return resultado;

}

export const FiltrarObjeto = (obj) => {

    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line => {
            line.words.forEach(word => {
                if (word.text[0] === "1" && word.text[1] === "2") {
                    resultado = word.text;
                }
            });
        });
    });

    return resultado;
}