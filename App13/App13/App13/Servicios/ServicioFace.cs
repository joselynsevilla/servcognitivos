﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using App13.Helpers;
using App13.Modelos;
namespace App13.Servicios
{
  public class ServicioFace
    {
        public static async Task<Emocion> ObtenerEmocion(MediaFile foto)
        {
            Emocion emocion = null;

            try
            {
                if (foto != null)
                {
                    var clienteFace = new FaceServiceClient(Constantes.FaceApiKey, Constantes.FaceApiURL);
                    var atributosFace = new FaceAttributeType[] { FaceAttributeType.Emotion };

                    using (var stream = foto.GetStream())
                    {
                        Face[] rostros = await clienteFace.DetectAsync(stream, false, false, atributosFace);

                        if (rostros.Any())
                        {
                            var analisisEmocion = rostros.FirstOrDefault().FaceAttributes.Emotion.ToRankedList().FirstOrDefault();
                            emocion = new Emocion()
                            {
                                Nombre = analisisEmocion.Key,
                                Score = analisisEmocion.Value,
                                Foto = foto.Path
                            };
                        }

                        foto.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return emocion;
        }
    }
}
