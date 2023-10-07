using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _prompt;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _volumeValue;

    private List<string> _dialogues;
    private List<Sprite> _sprites;
    private int _counter = 0;
    private Coroutine _printTextJob;
    public event UnityAction DialogueEnded;

    private void Start()
    {
        _source.volume = _volumeValue;
        _source.playOnAwake = false;
        _prompt.SetActive(false);
    }

    public void SetSpritesAndStrokes(List<string> dialogues, List<Sprite> sprites)
    {
        _dialogues = dialogues;
        _sprites = sprites;
    }

    public void SetNextText()
    {
        if (_counter == _dialogues.Count)
        {
            DialogueEnded?.Invoke();
            return;
        }

        _text.text = "";
        _prompt.SetActive(false);
        _image.sprite = _sprites[_counter];

        if (_printTextJob != null)
            StopCoroutine(_printTextJob);

        _printTextJob = StartCoroutine(PrintText(_dialogues[_counter]));
        _counter++;
    }

    private IEnumerator PrintText(string stroke)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        for (int i = 0; i < stroke.Length; i++)
        {
            _text.text += stroke[i];
            _source.Play();
            yield return delay;
        }

        _source.Stop();
        _prompt.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNextText();
        }
    }

    public void ResetCounter()
    {
        _counter = 0;
    }
}
